namespace NB_API.Models
{
    public class DeltagerDto
    {
        public int Id { get; set; }
        public int BrugerId { get; set; }
        public int EventId { get; set; }
        public BrugerDto? Bruger { get; set; }
        public Event? Event { get; set; }
    }
}
