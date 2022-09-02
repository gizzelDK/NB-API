namespace NB_API.Models
{
    public class SamarbejdeAnmodning
    {
        public int Id { get; set; }
        public ICollection<Bryggeri>? Bryggerier { get; set; }
    }
}
