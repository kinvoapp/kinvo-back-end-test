using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities.Financial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquota.Service.BusinessLogicServices
{
    public class RescueApplicationService
    {

        public bool ValidateThatDtRescueSmallerThanDtApplication(DateTime dtApplicationRegister, DateTime dtRescue)
        {

            if (dtApplicationRegister > dtRescue)
                throw new Exception("A data de resgate não pode ser menor que a data de aplicação.");

            return true;
        }

        public decimal CalculateTaxFromRescue(List<Tax> taxes, DateTime dtRegister, DateTime dtRescue)
        {
            int qtDaysDifference = dtRescue.Subtract(dtRegister).Days;

            var listTaxesVlPercentDiscount = taxes.Where(t => Enumerable.Range(t.QtMinDayDiscount, t.QtMinDayDiscount).Contains(qtDaysDifference));

            if (listTaxesVlPercentDiscount.Count() == 0 || listTaxesVlPercentDiscount.Count() > 1)
            {
                throw new Exception("ATENÇÃO: Taxas de recolhimento configuradas errado no Banco de dados.");
            }

            return listTaxesVlPercentDiscount.Single().VlPercentageDiscount;
        }

    }
}
