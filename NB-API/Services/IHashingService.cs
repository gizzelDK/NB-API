using NB_API.Models;
using System.IdentityModel.Tokens.Jwt;

namespace NB_API.Services
{
    public interface IHashingService
    {
        Array[] CreateHash(string pw);
        bool VerifyHash(string toBeHashed, byte[] hash, byte[] salt);
        string CreateToken(Bruger bruger);
        //bool VeriryBrugerId(int id, JwtSecurityToken token);
    }
}
