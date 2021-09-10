using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aliquota.Domain.Entidades
{
    [Table("TbClienteProdutoFinanceiro")]
    public class ClienteProdutoFinanceiro
    {
        public int ClienteId { get; set; }
        public int ProdutoFinanceiroId { get; set; }
        public Cliente Cliente { get; set; }
        public ProdutoFinanceiro ProdutoFinanceiro { get; set; }

        [Column("ValorInvestido")]
        public decimal Saldo { get; set; }

        public DateTime DataAplicacao { get; set; }

        public DateTime DataResgate { get; set; }



        public ClienteProdutoFinanceiro() { }



        public bool AplicarInvestimento(decimal a_ValorAplicado)
        {
            if (a_ValorAplicado <= 0)
            {
                return false;
            }

            var l_Cliente = new Cliente()
            {
                Id = 1,
                Nome = "Marcos",
                Cpf = "605.869.413-20"
            };

            var l_ProdutoFinanceiro = new ProdutoFinanceiro()
            {
                Id = 1,
                Nome = "XInvest",
                TaxaJuros_aa = 0.5M //5% a.a.
            };

            var l_ClienteProdutoFinanceiro = new ClienteProdutoFinanceiro()
            {
                ClienteId = 1,
                ProdutoFinanceiroId = 1,
                DataAplicacao = DateTime.Now
            };

            var l_Transacao = new Transacao()
            {
                DataTransacao = DateTime.Now,
                SentidoTransacao = Enums.SentidoTransacao.Entrada,
                Cliente = l_Cliente,
                ProdutoFinanceiro = l_ProdutoFinanceiro,
                ClienteProdutoFinanceiro = l_ClienteProdutoFinanceiro,
            };


            l_Transacao.ClienteProdutoFinanceiro.Saldo += a_ValorAplicado;
            SalvarTransacao(l_Transacao);
            SalvarClienteProdutoFinanceiro(l_ClienteProdutoFinanceiro);
            return true;
        }

        public bool ResgatarInvestimento(DateTime a_DataResgate)
        {
            decimal IR = 0;
            decimal l_ValorLiquido = 0;

            var l_Cliente = new Cliente()
            {
                Id = 1,
                Nome = "Marcos",
                Cpf = "605.869.413-20"
            };

            var l_ProdutoFinanceiro = new ProdutoFinanceiro()
            {
                Id = 1,
                Nome = "XInvest",
                TaxaJuros_aa = 0.5M //5% a.a.
            };

            var l_ClienteProdutoFinanceiro = new ClienteProdutoFinanceiro()
            {
                ClienteId = 1,
                ProdutoFinanceiroId = 1,
                Saldo = 5000
            };

            var l_Transacao = new Transacao()
            {
                DataTransacao = DateTime.Now,
                Cliente = l_Cliente,
                ProdutoFinanceiro = l_ProdutoFinanceiro,
                ClienteProdutoFinanceiro = l_ClienteProdutoFinanceiro,
            };

            //Validacao da Data de Resgate
            if (a_DataResgate < l_Transacao.ClienteProdutoFinanceiro.DataAplicacao)
            {
                return false;
            }

            TimeSpan l_DuracaoDoInvestido = l_Transacao.ClienteProdutoFinanceiro.DataAplicacao.Subtract(l_Transacao.ClienteProdutoFinanceiro.DataResgate);

            DateTime l_PeriodoInvestido = new DateTime(l_DuracaoDoInvestido.Ticks);

            //ValorFuturo = ValorPresente(1 + taxa * periodo)
            var l_VF = l_Transacao.ClienteProdutoFinanceiro.Saldo * (1 + (l_Transacao.ProdutoFinanceiro.TaxaJuros_aa / 12) * l_PeriodoInvestido.Month);

            //Investimento até 1 ano:
            if (l_PeriodoInvestido.Year <= 1)
            {
                IR = 0.225M * (l_VF - l_Transacao.ClienteProdutoFinanceiro.Saldo);
                l_ValorLiquido = l_VF - IR;

                return true;
            }

            //Investimento entre 1 e 2 anos:
            if (l_PeriodoInvestido.Year <= 2)
            {
                IR = 0.185M * (l_VF - l_Transacao.ClienteProdutoFinanceiro.Saldo);
                l_ValorLiquido = l_VF - IR;

                return true;
            }

            //Investimento maior que 2 anos:

            IR = 0.150M * (l_VF - l_Transacao.ClienteProdutoFinanceiro.Saldo);
            l_ValorLiquido = l_VF - IR;

            return true;
        }


        public void SalvarTransacao(Transacao a_Transacao)
        {
            //Métdo para salvar a transacao no banco.
        }

        public void SalvarClienteProdutoFinanceiro(ClienteProdutoFinanceiro a_ClienteProdutoFinanceiro)
        {
            //Método para salvar o clienteProdutoFinanceiro no banco.
        }
    }
}
