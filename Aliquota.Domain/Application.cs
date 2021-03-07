using System;

namespace Aliquota.Domain
{
    public class Application
    {
        public float Value { get; private set; }
        public float Profit { get; private set; }
        public float IncomeTax { get; private set; }
        public DateTime ApplyDate { get; private set; }
        public DateTime WithdrawDate { get; private set; }
        public Account _Account { get; private set; }
        //public Asset _Asset { get; private set; }

        public Application(Account account, float value, DateTime applyDate)
        {
            _Account = account;
            Value = value;
            ApplyDate = applyDate;
        }

        //Using a fixed appreciation range(0% to 10%) for test purposes
        public void CalculateProfit(int months)
        {
            for (int i = 0; i < months; i++)
            {
                var random = new Random();
                float appreciation = random.Next(0, 11) / 100;

                Profit = Value * appreciation;
            }
        }
    }
}
