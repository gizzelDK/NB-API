using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Security.Cryptography;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace NB_API.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly IDataProtector _protector;
        public CryptoService(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("DD2D957D-C63F-4D52-9CDC-58D83D652D6D"); //key to encrypt string
        }

        public string encrypt(string text)
        {
        var returntxt = _protector.Protect(text);
            return returntxt;
        }

        public string decrypt(string textFromEncrypted)
        {
            var returntxtfromencrypt = _protector.Unprotect(textFromEncrypted);
            return returntxtfromencrypt;
        }
        

        


    }
}

