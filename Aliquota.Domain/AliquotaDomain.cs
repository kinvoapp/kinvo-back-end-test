using System;

namespace Aliquota.Domain 
{
    public class AliquotaDomain 
    {
        public double rentA, rentM, lucro, valor, bruto;
        public int meses;

        public double rendimentoA() 
        {
            return rentA = (rentA / 100) * 6.15;
            // CDI = 6.15
        }
        public double rendimentoM() 
        {
            return rentM = rentA / 12;
            // Rendimento por mês
        }
        public double vlucro() 
        {
            return lucro = rendimentoM() * valor / 100 * (meses);
        }
        public double vbruto() 
        {
            return bruto = vlucro() + valor;
        }

    }
}
