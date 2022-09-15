namespace NB_API.Models
{
    public class ForumTags
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public int TagId { get; set; }
        public Forum? Forum { get; set; }
        public Tag? Tag { get; set; }
    }
}
