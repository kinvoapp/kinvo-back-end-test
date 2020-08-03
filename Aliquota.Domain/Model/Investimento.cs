using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.Domain.Model
{
    [Table("Investimento")]
    public class Investimento
    {
        public Guid Id { get; set; }
        public decimal Total { get { return ValorInvestimento + ValorLucro; } }
        public decimal ValorInvestimento { get; set; }
        public decimal ValorLucro { get; set; }
        public DateTime DataInvestimento { get; set; }
        public DateTime? DataRetornado { get; set; }
        public uint ProdutoId { get; set; }
        public Guid CarteiraId { get; set; }

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

        

        public Investimento(Guid guid,decimal valor, uint produto, Guid carteira) 
        {
            Id = guid;
            DataInvestimento = DateTime.Now;
            ValorLucro = 0M;
            ValorInvestimento = valor;
            ProdutoId = produto;
            CarteiraId = carteira;
            ValidarModel();
        }

        public bool ValidarModel()
        {
            if(ValorInvestimento <= 0)
            {
                throw new ArgumentException("Valor da aplicação não pode ser inferior ou igual a zero!");
            }else if(ProdutoId <= 0)
            {
                throw new ApplicationException("Instância do produto não pode ser nulo");
            }else if(CarteiraId == null)
            {
                throw new ApplicationException("Instancia da carteira não pode ser nulo");
            }
            return true;
        }
        public bool ValidarData(DateTime date)
        {
            if(DataInvestimento > date)
            {
                throw new ArgumentException("Data de Saque anterior a data de aplicação!");
            }
            return true;
        }

        public decimal RetornarLucro(DateTime dataRetornado)
        {
            if (ValidarData(dataRetornado))
            {

                var taxaPorMes = (double)Produto.TaxaAnual / 12;
                int meses = PegarDiferencaEmMesesEntreDuasDatas(DataInvestimento, dataRetornado);
                decimal rendimento = Total;

                return (rendimento * (Decimal)Math.Pow((1 + taxaPorMes/100),meses)) - rendimento;// Juros Composto Vr Futuro, retorn jurs
            }
            return 0;
        }

        public void RetornarInvestimentoParaCarteira(DateTime dataRetornado)
        {
            try
            {
                if (ValidarData(dataRetornado))
                {
                    var IR = RetornarImpostoDeRendaPorAno(dataRetornado);
                    ValorLucro = RetornarLucro(dataRetornado) - IR;
                    Carteira.Valor += Total;
                    DataRetornado = dataRetornado;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AtualizarLucro(DateTime dataRetornado)
        {
            ValorLucro = RetornarLucro(dataRetornado);
        }

        private int PegarDiferencaEmMesesEntreDuasDatas(DateTime inicial, DateTime Final)
        {
            return (((inicial.Year - Final.Year) * 12)
                + inicial.Month - Final.Month) * (-1);
        }

        public decimal RetornarImpostoDeRendaPorAno(DateTime anoFinal)
        {
            decimal retorno = 0;
            if (ValidarData(anoFinal))
            {
                AtualizarLucro(anoFinal);
                var anoRendimento = PegarDiferencaEmMesesEntreDuasDatas(DataInvestimento,anoFinal);

                retorno = anoRendimento <= 12 ? ValorLucro * (22.5M / 100) :
                        anoRendimento > 12 && anoRendimento <= 24 ? ValorLucro * (18.5M / 100) :
                        ValorLucro * (15M / 100);
            }
            return retorno;
        }
    }
}
