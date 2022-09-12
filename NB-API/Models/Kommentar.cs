namespace NB_API.Models
{
    public class Kommentar
    {
        public int Id { get; set; }
        public string? Tekst { get; set; } = "";
        public int OlId { get; set; }
        public Øl? Ol { get; set; }
        public int Rating { get; set; }
        public int ForfatterId { get; set; }
        public Bruger? Forfatter { get; set; }
    }
}
