namespace NB_API.Models
{
    public class Kontaktoplysninger
    {
        public int Id { get; set; }
        public string? Enavn { get; set; }
        public string? Fnavn { get; set; }
        public string Addresselinje1 { get; set; }
        public string? Addresselinje2 { get; set; }
        public int Postnr { get; set; }
        public string By { get; set; }
        public string Email { get; set; }
        public string? TelefonNr { get; set; }
        public Bryggeri? Bryggeri { get; set; }
    }
}
