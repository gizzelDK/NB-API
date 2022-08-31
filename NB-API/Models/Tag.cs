namespace NB_API.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public ICollection<Event>? Events { get; set; }
        public ICollection<Forum>? Forum { get; set; }
        public ICollection<Øl>? Øl { get; set; }
    }
}
