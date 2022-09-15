namespace NB_API.Models
{
    public class ØlTags
    {
        public int Id { get; set; }
        public int ØlId { get; set; }
        public int TagId { get; set; }
        public Øl? Øl { get; set; }
        public Tag? Tag { get; set; }
    }
}
