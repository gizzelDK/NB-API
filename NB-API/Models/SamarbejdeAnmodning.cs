namespace NB_API.Models
{
    public class SamarbejdeAnmodning
    {
        public int Id { get; set; }
        public int BryggerId1 { get; set; }
        public int BryggerId2 { get; set; }
        public Bryggeri? Bryggeri { get; set; }
    }
}
