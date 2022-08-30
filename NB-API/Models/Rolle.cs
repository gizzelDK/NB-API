namespace NB_API.Models
{
    public enum RolleNavn
    {
        AnonymBruger = 0,
        Bruger = 10,
        Administrator = 20
    }
    public partial class Rolle
    {
        public int Id { get; set; }
        public RolleNavn RolleNavn { get; set; }
        public int Level { get; set; }
    }
}
