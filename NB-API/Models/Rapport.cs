namespace NB_API.Models
{
    public enum RapportType
    {
        Andet = 0,
        Fejl = 1,
        Anmeld = 2,
        Spørgsmål = 3
    }
    public class Rapport
    {
        public int Id { get; set; }
        public int BrugerId { get; set; }
        public int? AnklagetBrugerId { get; set; }
        public Bruger? Bruger { get; set; }
        public string Titel { get; set; }
        public string Besked { get; set; }
        public RapportType? RType { get; set; }
        public bool? Godtaget { get; set; }

    }
}
