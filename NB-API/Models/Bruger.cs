namespace NB_API.Models
{
    public class Bruger
    {
        public int Id { get; set; }
        public string Brugernavn { get; set; } = string.Empty;
        public byte[]? PwHash { get; set; }
        public byte[]? PwSalt { get; set; }
        public int RolleId { get; set; }
        public Rolle? Rolle { get; set; }
        public int? KontaktoplysningerId { get; set; }
        public Kontaktoplysninger? Kontaktoplysninger { get; set; }
        public ICollection<Event>? Events { get; set; }
        public ICollection<Bryggeri>? Follows { get; set; }
        public ICollection<Rapport>? Rapporter { get; set; }
        public ICollection<Certifikat>? Certifikats { get; set; }
        public bool AcceptedPolicy { get; set; } = false;
        public bool Deleted { get; set; } = false;
        

    }
}
