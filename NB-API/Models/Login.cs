using System.ComponentModel.DataAnnotations;
namespace NB_API.Models
{
    public class Login
    {
        public int Id { get; set; }
        public int BrugerId { get; set; }
        public Bruger? Bruger { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
