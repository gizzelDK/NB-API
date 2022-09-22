namespace NB_API.Models
{
    public class BryggeriFollowers
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public int BryggeriId { get; set; }
        public Bruger? Folloer { get; set; }
        public Bryggeri? Bryggeri { get; set; }
    }
}
