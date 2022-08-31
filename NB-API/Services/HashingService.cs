using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using NB_API.Models;

namespace NB_API.Services
{

    public class HashingService
    {
        private string _hash = string.Empty;
        private string salt = string.Empty;
        private readonly IConfiguration _configuration;
        public HashingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private bool VerifyPasswordHash(string pw, byte[] pwHash, byte[] pwSalt)
        {
            using (var hmac = new HMACSHA512(pwSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pw));
                return computedHash.SequenceEqual(pwHash);
            }
        }
        private void CreatePasswordHash(string pw, out byte[] pwHash, out byte[] pwSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                pwSalt = hmac.Key;
                pwHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pw));
            }
        }
        
        private string CreateToken(Bruger bruger)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Name", bruger.Brugernavn),
                new Claim("Id", bruger.Id.ToString()),
                new Claim("Role", bruger.Rolle.RolleNavn.ToString()),
                new Claim("Level", bruger.Rolle.Level.ToString()),
                new Claim(ClaimTypes.Role, bruger.Rolle.RolleNavn.ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Security:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
