
using Income.Tax.Willian.Santos.Kinvo.Domain.Entities;
using Income.Tax.Willian.Santos.Kinvo.Domain.Entities.Relationships;
using Income.Tax.Willian.Santos.Kinvo.Domain.Enum;
using Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Income.Tax.Willian.Santos.Kinvo.Domain.Services
{
    public class CalculateAliquotITService : ICalculateAliquotITService
    {

        public ApplicationIT GetTimeAction(ApplicationIT aplication)
        {
            DateTime redemptionDate = DateTime.Now;
            int timeApplicationDays = (int)redemptionDate.Subtract(aplication.ContributionTime).TotalDays;
            int timeApplicationMonth = timeApplicationDays / 30;

            aplication.SetTimeAction(timeApplicationMonth, timeApplicationDays);

            return aplication;
        }

        public ApplicationIT GetFullProfitWithCompostInterest(ApplicationIT application)
        {
            float fullprofit = 0;
            float compoundInterest = 0.2F;

            /*      Não houve diretriz em relação ao juros composto na descrição dos requisitos,
                porém, a maior parte dos valores investidos há a atribuição do juros,
                então assumindo que o valor do juros composto é de 2 % e mensal:                 */

            new List<int>(Enumerable.Range(1, (application.TimeAction.QuantityMonths))).Select((index, value) => new { index, value }).ToList()
                                .ForEach(x =>
                                {
                                    fullprofit = x.index switch
                                    {
                                        0 => (application.Value * compoundInterest) + application.Value,
                                        _ => (fullprofit * compoundInterest) + fullprofit
                                    };
                                });
            application.SetFullProfit(fullprofit);
            return application;
        }

        public ApplicationIT GetApplicationInterest(ApplicationIT application)
        {
            float interest;

            if (application.TimeAction.QuantityDays<= (int)ETimeType.LessThanOrEqualToOneYear) { interest = 22.5f / 100; }

            else
            if (application.TimeAction.QuantityDays >= (int)ETimeType.GreaterThanOneYearAndLessThanOrEqualToTwoYears &&
                application.TimeAction.QuantityDays < (int)ETimeType.GreaterThanTwoYears) { interest = 18.5f / 100; }

            else
            if (application.TimeAction.QuantityDays <= (int)ETimeType.GreaterThanTwoYears) { interest = (float)15 / 100; }

            else { interest = 0; }

            application.SetProfitWithInterest(interest);
            return application;
        }
    }
}
