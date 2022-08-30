using System.ComponentModel.DataAnnotations;
namespace NB_API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int BrugerId { get; set; }
        public Bruger? Bruger { get; set; }
        public string Titel { get; set; }
        public string Indhold { get; set; }
        [Timestamp]
        public DateTime Oprettet { get; set; }
        public int? PostId { get; set; }
        public Post? Svarer { get; set; }
        public int ForumId { get; set; }
        public Forum? Forum { get; set; }
    }
}
