namespace NB_API.Models
{
    public class Bryggeri
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public int? KontaktoplysningerId { get; set; }
        public Kontaktoplysninger? Kontaktoplysninger { get; set; }
        public string? Beskrivelse { get; set; }
        public string? BryggeriLogo { get; set; }
        public ICollection<Samarbejde>? Samarbejde { get; set; }
        public ICollection<Tag>? Tags { get; set; }
        public ICollection<Bruger>? Followers { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime? DeleteTime { get; set; }
    }
}
