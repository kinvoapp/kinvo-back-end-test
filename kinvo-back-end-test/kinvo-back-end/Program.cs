using Aliquota.Domain;
using System;
using System.Text;

namespace kinvo_back_end
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AliquotaDomain aliquota = AliquotaDomain.InsertData();
                AliquotaDomain.FinancialProductCalculation(aliquota);
                AliquotaDomain.IRCalculation(aliquota);
                StringBuilder sBuilder = new StringBuilder();
                sBuilder.AppendLine($"Cliente: {aliquota.Costumer}");
                sBuilder.AppendLine($"Valor Total das Aplicações Mensais: {aliquota.TotalValueApplication}");
                sBuilder.AppendLine($"Data Inicial das Aplicações: {aliquota.DateApplication}");
                sBuilder.AppendLine($"Data da retirada: { aliquota.DateRetired}");
                sBuilder.AppendLine($"Lucro[% do Valor Total Aportado] : { aliquota.Profit}");
                sBuilder.AppendLine($"Valor a ser Pago pelo IR: {aliquota.DiscountValueIR}");

                Console.WriteLine(sBuilder);

                using (var db = new AliquotaDomainContext())
                {
                    db.AliquotaDomains.Add(aliquota);
                    db.SaveChanges();
                }
            }
            catch (Exception except)
            {
                Console.WriteLine(except.Message);
            }
            
        }
    }
}
