namespace NB_API.Models
{
    public class SamarbejdeAnmodning
    {
        public int Id { get; set; }
        public int BryggeriId1 { get; set; }
        public int BryggeriId2 { get; set; }
        public Bryggeri? Bryggeri { get; set; }
    }
}
