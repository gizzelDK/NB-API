namespace NB_API.Models
{
    public class Opskrift
    {
        public int Id { get; set; }
        public int? OlId { get; set; }
        public Øl? Ol { get; set; }
        public int? BryggeriId { get; set; }
        public Bryggeri? Bryggeri { get; set; }
        public string StepOne { get; set; } = string.Empty;
        public string StepTwo { get; set; } = string.Empty;
        public string StepThree { get; set; } = string.Empty;
        public string StepFour { get; set; } = string.Empty;
        public string StepFive { get; set; } = string.Empty;
        public bool Offentliggjort { get; set; } = false;
    }
}
