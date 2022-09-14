namespace NB_API.Models
{
    public class EventTags
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int TagId { get; set; }
        public Event? Event { get; set; }
        public Tag? Tag { get; set; }
    }
}
