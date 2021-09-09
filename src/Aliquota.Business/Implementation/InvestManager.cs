using Aliquota.Business.Interfaces;
using Aliquota.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Business.Implementation
{
    public class InvestManager : IInvestManager
    {
        private const double IMP1 = 0.225;
        private const double IMP2 = 0.185;
        private const double IMP3 = 0.15;

        private readonly IInvestRepository investRepository;

        public InvestManager(IInvestRepository investRepository)
        {
            this.investRepository = investRepository;
        }

        public async Task<IEnumerable<Invest>> GetInvestsAsync()
        {
            return await investRepository.GetInvestsAsync();
        }

        public async Task<Invest> GetInvestAsync(int id)
        {
            return await investRepository.GetInvestAsync(id);
        }

        public async Task<Invest> UpdateInvestAsync(Invest invest)
        {
            return await investRepository.UpdateInvestAsync(invest);
        }

        public async Task<Invest> InsertInvestAsync(Invest invest)
        {
            var valid = ValidateValue(invest.InvestedValue);

            if (!valid)
            {
                return null;
            }

            return await investRepository.InsertInvestAsync(invest);
        }

        public async Task DeleteInvestAsync(int id)
        {
            await investRepository.DeleteInvesAsync(id);
        }

        public async Task<Invest> RescueInvestAsync(Invest invest)
        {
            var valid = ValidateValue(invest.InvestedValue);

            if (!valid)
            {
                return null;
            }
            var retention = ValueRetention(invest.AppDate);
            var control = invest.InvestedValue * retention;
            invest.InvestedValue -= control;
            return await investRepository.RescueInvestAsync(invest);

        }


        public  bool ValidateValue(double value)
        {
            if (value <= 0)
                return false;

            return true;
        }



        public  double ValueRetention(DateTime date)
        {
            TimeSpan result = DateTime.Now - date;

            var result2 = result.Days/30;

            if (result2 < 12)
            {
                return IMP1;
            }
            else if (result2 >= 12 || result2 <= 24)
            {
                return IMP2;
            }
            else
            {
                return IMP3;
            }


        }

    }
}
