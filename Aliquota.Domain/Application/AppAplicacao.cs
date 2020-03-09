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
            i_InterfaceAplicacao.Adicionar(a_Aplicacao);
        }
        public void Atualizar(Aplicacao a_Aplicacao)
        {
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

        public decimal ImpostoRendaDevido(Aplicacao a_Aplicacao)
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

            if (l_PeriodoAplicacao <= 12)
                return l_Lucro * (decimal)1.225;

            if (l_PeriodoAplicacao > 12 && l_PeriodoAplicacao <= 24)
                return l_Lucro * (decimal)1.185;
           
            return l_Lucro * (decimal)1.15;
        }
    }
}
