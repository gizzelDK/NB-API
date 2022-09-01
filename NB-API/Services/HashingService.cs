using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using NB_API.Models;

namespace NB_API.Services
{

    public class HashingService : IHashingService
    {
        private readonly IConfiguration _configuration;
        public HashingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // Tager string og prøver at genskabe pwhash med pwsalt hashet
        public bool VerifyHash(string pw, byte[] pwHash, byte[] pwSalt)
        {
            using (var hmac = new HMACSHA512(pwSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pw));
                return computedHash.SequenceEqual(pwHash);
            }
        }
        // Danner salt og hash ud fra string
        public Array[] CreateHash(string pw)
        {
            Array[] byteArr = new Array[2];
            byte[] pwHash = null;
            byte[] pwSalt = null;

            using (var hmac = new HMACSHA512())
            {
                pwSalt = hmac.Key;
                pwHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pw));
                byteArr[1] = pwHash;
                byteArr[0] = pwSalt;

                return byteArr;
            }
        }
        // Danner et JWT token med de ønskede claims og returnerer Token
        public string CreateToken(Bruger bruger)
        {
            List<Claim> claims = new List<Claim>
            {
                // Hjemmelavede claims til angular siden
                new Claim("Name", bruger.Brugernavn),
                new Claim("Id", bruger.Id.ToString()),
                new Claim("Role", bruger.Rolle.RolleNavn.ToString()),
                new Claim("Level", bruger.Rolle.Level.ToString()),
                // Prædefineret claimtype ud fra rolle - til api siden
                new Claim(ClaimTypes.Role, bruger.Rolle.RolleNavn.ToString())
            };
            // Pakker informationer ind i JWT token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Security:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        //public bool VeriryBrugerId(int id, string token)
        //{
        //    if (id.ToString() != token.Id)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
