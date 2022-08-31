using NB_API.Models;
namespace NB_API.Services
{
    public interface IHashingService
    {
        string CreateHash(string toBeHashed, out byte[] hash, out byte[] salt);
        bool VerifyHash(string toBeHashed, byte[] hash, byte[] salt);
        string CreateToken(Bruger bruger);
    }
}
