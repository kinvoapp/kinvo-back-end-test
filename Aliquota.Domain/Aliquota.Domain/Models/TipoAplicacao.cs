namespace Aliquota.Domain.Models
{
    public class TipoAplicacao
    {
        public int ID { get; set; }
        public string NomeAplicacao { get; set; }
        public decimal Aliquota { get; set; }
        public decimal TempoAplicacao { get; set; }
        public decimal Lucro { get; set; }
    }
}
