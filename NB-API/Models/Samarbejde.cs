namespace NB_API.Models
{
    public class Samarbejde
    {
        public int Id { get; set; }
        public int ØlId { get; set; }
        public Øl? Øl { get; set; }
        public ICollection<Bryggeri>? Bryggerier { get; set; }
        public string Titel { get; set; }
    }
}
