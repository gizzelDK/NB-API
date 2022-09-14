namespace NB_API.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string? Beskrivelse { get; set; }
        public DateTime Oprettet { get; set; }
        public ICollection<ForumTags>? Tags { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public string? ForumBillede { get; set; }
        public int BrugerId { get; set; }
        public Bruger? Bruger { get; set; }
    }
}
