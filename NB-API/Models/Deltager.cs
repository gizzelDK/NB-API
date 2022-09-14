namespace NB_API.Models
{
    public class Deltager
    {
        public int Id { get; set; }
        public int BrugerId { get; set; }
        public Bruger? Bruger { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }
    }
}
