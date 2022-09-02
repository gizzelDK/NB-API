namespace NB_API.Models
{
    public class Samarbejde
    {
        public int Id { get; set; }
        public int OlId { get; set; }
        public Øl? Ol { get; set; }
        public ICollection<Bryggeri>? Bryggerier { get; set; }
        public string Titel { get; set; }
        public ICollection<SamarbejdeAnmodning>? SamarbejdeAnmodning { get; set; }
    }
}
