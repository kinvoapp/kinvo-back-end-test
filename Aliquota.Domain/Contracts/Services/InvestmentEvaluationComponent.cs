namespace Aliquota.Domain.Services
{
    public class InvestmentEvaluationComponent
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public double Value { get; set; } // Negative for abatements
    }

}