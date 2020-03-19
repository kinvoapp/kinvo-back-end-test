using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class AppAplicacao : IAppAplicacao
    {
        IAppAplicacao i_InterfaceAplicacao;

        public AppAplicacao(IAppAplicacao a_IAplicacao)
        {
            i_InterfaceAplicacao = a_IAplicacao;
        }

        public void Adicionar(Aplicacao a_Aplicacao)
        {
            if (!ValidarAplicacao(a_Aplicacao))
                throw new ApplicationException("Aplicação inválida");

            i_InterfaceAplicacao.Adicionar(a_Aplicacao);
        }
        public void Atualizar(Aplicacao a_Aplicacao)
        {
            if (!ValidarAplicacao(a_Aplicacao))
                throw new ApplicationException("Aplicação inválida");

            i_InterfaceAplicacao.Atualizar(a_Aplicacao);
        }
        public void Excluir(Aplicacao a_Aplicacao)
        {
            i_InterfaceAplicacao.Excluir(a_Aplicacao);
        }
        public Aplicacao ObterPorId(int a_AplicacaoID)
        {
            return i_InterfaceAplicacao.ObterPorId(a_AplicacaoID);
        }
        public List<Aplicacao> Listar()
        {
            return i_InterfaceAplicacao.Listar();
        }

        public static decimal ImpostoRendaDevido(Aplicacao a_Aplicacao)
        {
            if (!a_Aplicacao.DataRetirada.HasValue)
                return 0;
            
            int l_PeriodoAplicacao = ((a_Aplicacao.DataRetirada.Value.Year - a_Aplicacao.DataAplicacao.Year) * 12) + a_Aplicacao.DataRetirada.Value.Month - a_Aplicacao.DataAplicacao.Month;

            decimal l_RendimentoBruto = a_Aplicacao.Valor;
            for (int i = l_PeriodoAplicacao; i > 0; i--)
            {
                l_RendimentoBruto = l_RendimentoBruto + (l_RendimentoBruto * a_Aplicacao.Produto.Rendimento);
            }

            decimal l_Lucro = l_RendimentoBruto - (a_Aplicacao.Produto.Custo * l_PeriodoAplicacao);

            decimal l_PercentualIR = ObterPercentualIR(l_PeriodoAplicacao);

            return l_Lucro * l_PercentualIR;            
        }

        public static decimal ObterPercentualIR(int a_PeriodoAplicacao)
        {
            if (a_PeriodoAplicacao <= 12)
                return (decimal)1.225;

            if (a_PeriodoAplicacao > 12 && a_PeriodoAplicacao <= 24)
                return (decimal)1.185;

            return (decimal)1.15;
        }

        public static bool ValidarAplicacao(Aplicacao a_Aplicacao)
        {
            if (a_Aplicacao != null && a_Aplicacao.Valor <= 0)
                return false;

            if (a_Aplicacao.DataRetirada.HasValue && a_Aplicacao.DataRetirada < a_Aplicacao.DataAplicacao)
                return false;

            return true;
        }
    }
}
