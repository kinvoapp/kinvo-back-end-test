using System;

namespace Aliquota.Domain
{
    public class Aplicacao
    {
        public int id;
        private double valorInicial;
        private double valorLucro;
        private DateTime dataCriacao;

        public Aplicacao(double valor)
        {
            try
            {
                if (valorInicial > 0)
                {
                    valorInicial = valor;
                    dataCriacao = DateTime.Now;
                } else
                {
                    throw new ArgumentException("O valor da aplicação não pode ser menor ou igual a zero.");
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
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
                if (dataCriacao != null && dataCriacao <= DateTime.Now)
                {
                    return valorInicial + valorLucro - TaxaIR();
                }
                else
                {
                    throw new ArgumentException("A data de resgate não pode ser inferior à data da aplicação.");
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private double TaxaIR()
        {
            int totalAnos = new DateTime((DateTime.Now - dataCriacao).Ticks).Year;
            if (totalAnos > 2)
            {
                return (valorLucro * 15) / 100;
            }
            else if (totalAnos > 1 && totalAnos <= 2)
            {
                return (valorLucro * 18.5) / 100;
            }
            else
            {
                return (valorLucro * 22.5) / 100;
            }
        }
    }
}
