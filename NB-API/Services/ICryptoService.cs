namespace NB_API.Services
{
    public interface ICryptoService
    {
        public string encrypt(string text);
        public string decrypt(string textFromEncrypted);

     
    }
}
