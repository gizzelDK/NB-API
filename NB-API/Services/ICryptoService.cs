namespace NB_API.Services
{
    public interface ICryptoService
    {
        string DecryptString(string encrString, string key);
        string EnryptString(string strEncrypted, string key);
    }
}
