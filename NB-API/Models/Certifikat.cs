namespace NB_API.Models
{
    public class Certifikat
    {
        public enum CertifikatStatus
        {
            IkkeSendt = 1,
            VentTilGodkendt = 2,
            Godkendt = 3
        }
        public int Id { get; set; }
        public CertifikatStatus? CStatus { get; set; } = CertifikatStatus.IkkeSendt;
        public string? CertifikatBilled { get; set; }
        public int BrugerId { get; set; }
        public Bruger? Bruger { get; set; }
    }
}
