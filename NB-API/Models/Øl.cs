namespace NB_API.Models
{
    public class Øl
    {
        public int Id { get; set; }
        public string Land { get; set; }
        public int BryggeriId { get; set; }
        public Bryggeri? Bryggeri { get; set; }
        public string Navn { get; set; }
        public string Type { get; set; }
        public float Procent { get; set; }
        public string Smag { get; set; }
        public string Beskrivelse { get; set; }
        public Opskrift? Bryggeprocess { get; set; }
        public string? OlBillede { get; set; }
        public DateTime Aargang { get; set; }
        public int? Antal { get; set; }
        public int? FlaskeAntal { get; set; }
        public int? TondeAntal { get; set; }
        public int? FlaskeResAntal { get; set; }
        public ICollection<ØlTags>? Tags { get; set; }
        public ICollection<Samarbejde>? Samarbejder { get; set; }
        public ICollection<Kommentar>? Kommentarer { get; set; }
    }
}
