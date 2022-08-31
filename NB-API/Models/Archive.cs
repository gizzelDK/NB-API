namespace NB_API.Models
{
    public class Archive
    {
        public int Id { get; set; }
        public int BrugerId { get; set; }
        public Bruger Bruger { get; set; }
        public int KontaktoplysningerId { get; set; }
        public Kontaktoplysninger Kontaktoplysninger { get; set; }
        public DateTime Oprettet { get; set; }
    }
}
