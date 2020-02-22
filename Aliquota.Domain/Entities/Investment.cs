using Aliquota.Domain.Entities.Exceptions;


namespace Aliquota.Domain.Entities
{
    public class Investment
    {
        public double InitialAmount { get; set; }
        public double Interest { get; set; }
        public double Profit { get; set; }

        public Investment(double initialAmount)
        {
            InitialAmount = initialAmount;
            if (InitialAmount <= 0)
            {
                throw new CalculateException("Starting amount cannot be less than or equal to zero");
            }
        }
    }
}
