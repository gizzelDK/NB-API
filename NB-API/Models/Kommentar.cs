namespace NB_API.Models
{
    public class Kommentar
    {
        public int Id { get; set; }
        public string Tekst { get; set; } = "";
        public int ØlId { get; set; }
        public Øl? Øl { get; set; }
        public int Rating { get; set; }
    }
}
