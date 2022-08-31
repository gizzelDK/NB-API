namespace NB_API.Models
{
    public class Opskrift
    {
        public int Id { get; set; }
        public int ØlId { get; set; }
        public Øl? Øl { get; set; }
        public string StepOne { get; set; }
        public string StepTwo { get; set; }
        public string StepThree { get; set; }
        public string StepFour { get; set; }
        public string StepFive { get; set; }
    }
}
