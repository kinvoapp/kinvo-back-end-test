using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.Domain.Model
{
    [Table("Carteira")]
    public class Investimento
    {
        public Guid Id { get; set; }
        public decimal Total { get { return ValorInvestimento + ValorLucro; } }
        public decimal ValorInvestimento { get; set; }
        public decimal ValorLucro { get
            { return ((DateTime.Now.Year - DataInvestimento.Year) * Produto.TaxaAnual * Total) - ValorInvestimento; } private set { } }
        public DateTime DataInvestimento { get; set; }
        public DateTime DataRetornado { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Carteira Carteira { get; set; }


        public Investimento()
        {

        }
        public Investimento(decimal valor)
        {
            ValorInvestimento = valor;
            ValidarModel();
        }
        public Investimento(Guid guid,decimal valor, Produto produto, Carteira carteira) 
        {
            Id = guid;
            DataInvestimento = DateTime.Now;
            ValorLucro = 0M;
            ValorInvestimento = valor;
            Produto = produto;
            Carteira = carteira;
            ValidarModel();
        }

        public bool ValidarModel()
        {
            if(ValorInvestimento <= 0)
            {
                throw new ArgumentException("Valor da aplicação não pode ser inferior ou igual a zero!");
            }else if(Produto == null)
            {
                throw new ApplicationException("Instância do produto não pode ser nulo");
            }else if(Carteira == null)
            {
                throw new ApplicationException("Instancia da carteira não pode ser nulo");
            }
            return true;
        }


        internal void RetornarInvestimentoParaCarteira()
        {
            try
            {
                DataRetornado = DateTime.Now;
                var IR = RetornarImpostoDeRenda();
                ValorLucro -= IR;
                Carteira.Valor += Total;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal RetornarImpostoDeRenda()
        {
            if(DataRetornado != null)
            {
                throw new ApplicationException("O investimento ainda não foi retornado");
            }

            var anoRendimento = DateTime.Now.Year - DataInvestimento.Year;

            return  anoRendimento <= 1 ? ValorLucro * (22.5M / 100 ):
                    anoRendimento > 1 && anoRendimento <= 2 ? ValorLucro * (18.5M / 100) :
                    ValorLucro * (15M / 100);
        }
    }
}
