using System;

namespace Aliquota.Domain
{
    public class Aplicacao
    {
        public int Id;
        private double ValorInicial;
        public double ValorLucro { get; set; }
        public DateTime DataCriacao { get; set; }

        public Aplicacao(double valor)
        {
            try
            {
                if (valor > 0)
                {
                    ValorInicial = valor;
                    DataCriacao = DateTime.Now;
                } else
                {
                    throw new ArgumentException("O valor da aplicação não pode ser menor ou igual a zero.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double ResgatarAplicacao()
        {
            try
            {
                if (DataCriacao <= DateTime.Now)
                {
                    return ValorInicial + ValorLucro - TaxaIR();
                }
                else
                {
                    throw new ArgumentException("A data de resgate não pode ser inferior à data da aplicação.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double TaxaIR()
        {
            int totalAnos = new DateTime((DateTime.Now - DataCriacao).Ticks).Year;
            if (totalAnos > 2)
            {
                return (ValorLucro * 15) / 100;
            }
            else if (totalAnos > 1 && totalAnos <= 2)
            {
                return (ValorLucro * 18.5) / 100;
            }
            else
            {
                return (ValorLucro * 22.5) / 100;
            }
        }
    }
}
