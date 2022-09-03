namespace NB_API.Services
{
    public interface ICryptoService
    {
        //string DecryptString(byte encrString, string key);
        //string EnryptString(byte strEncrypted, string key);

        byte[] EncryptString(byte[] plaintext, byte[] key);
        byte[] DecryptString(byte[] plaintext, byte[] key);
    }
}
