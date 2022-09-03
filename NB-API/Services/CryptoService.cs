using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Aes = System.Security.Cryptography.Aes;

namespace NB_API.Services
{
    public class CryptoService : ICryptoService
    {
        //public string EnryptString(string encryptString, string key)
        //{
        //    string EncryptionKey = key;
        //    byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
        //    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        //});
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(clearBytes, 0, clearBytes.Length);
        //                cs.Close();
        //            }
        //            encryptString = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }
        //    return encryptString;
        //}

        //public string DecryptString(string cipherText, string key)
        //{
        //    string EncryptionKey = key;
        //    cipherText = cipherText.Replace(" ", "+");
        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
        //    using (Aes encryptor = Aes.Create())
        //    {
               
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
        //    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        //});
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
            
        //                cs.Write(cipherBytes, 0, cipherBytes.Length);
        //                cs.Close();
        //            }
        //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //        }
        //    }
        //    return cipherText;
        //}

        public static byte[] EncryptString(byte[] plaintext, byte[] key)
        {
            using (var aes = Aes.Create())
            {
                aes.BlockSize = 128;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.None;

                var encryptor = aes.CreateEncryptor(key, new byte[16]);
                using (var target = new MemoryStream())
                using (var cs = new CryptoStream(target, encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(plaintext, 0, plaintext.Length);
                    return target.ToArray();
                }
            }
        }

        public static byte[] DecryptString(byte[] plaintext, byte[] key)
        {
            using (var aes = Aes.Create())
            {
                aes.BlockSize = 128;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.None;

                var decryptor = aes.CreateDecryptor(key, new byte[16]);
                using (var target = new MemoryStream())
                using (var cs = new CryptoStream(target, decryptor, CryptoStreamMode.Write))
                {
                    cs.Write(plaintext, 0, plaintext.Length);
                    return target.ToArray();
                }
            }
        }
    }
 }

