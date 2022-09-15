namespace NB_API.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
        public string Lokation { get; set; }
        public string? EventBilled { get; set; }
        public ICollection<EventTags>? Tags { get; set; }
        public ICollection<Deltager>? Deltagelse { get; set; }
    }
}
