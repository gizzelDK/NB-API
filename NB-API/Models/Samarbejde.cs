namespace NB_API.Models
{
    public class Samarbejde
    {
        public int Id { get; set; }
        public int BryggeriId1 { get; set; }
        public int BryggeriId2 { get; set; }
        public Bryggeri? Bryggeri { get; set; }
        public string Titel { get; set; }
    }
}
