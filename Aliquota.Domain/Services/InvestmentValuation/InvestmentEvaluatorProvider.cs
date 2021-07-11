namespace Aliquota.Domain.Services
{
    public static class InvestmentEvaluatorProvider
    {
        public static IInvestmentEvaluator GetInvestmentEvaluator(InvestmentEvaluatorTypes types, object configuration)
        {
            return types switch {
                InvestmentEvaluatorTypes.ConstantMultiplier => 
                    new ConstantMultiplierEvaluator((ConstantMultiplierEvaluatorParams) configuration),
                InvestmentEvaluatorTypes.ImpostoDeRenda =>
                    new ImpostoDeRendaEvaluator((ImpostoDeRendaEvaluatorParams) configuration),
                _ => 
                    new ConstantMultiplierEvaluator((ConstantMultiplierEvaluatorParams) configuration),
            };
        }
    }
}