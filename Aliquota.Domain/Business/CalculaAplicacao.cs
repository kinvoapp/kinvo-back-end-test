using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business
{
    public class CalculaAplicacao
    {
        public decimal CalculaLucroBruto(decimal valorInicial, decimal valorFinalBruto)
        {
            if (valorInicial <= 0)
                return 0;
            return valorFinalBruto - valorInicial;
        }

        public decimal CalculaLucroLiquido(decimal valorImpostoRenda, decimal lucroBruto)
        {
            return lucroBruto - valorImpostoRenda;
        }

        public decimal CalculaImpostoRenda(DateTime dataAplicacao, DateTime dataRetirada, decimal lucroBruto)
        {
            if (lucroBruto <= 0)
                return 0;
            int anosAplicacao = CalculaIntervaloDatasAplicacao(dataAplicacao, dataRetirada);
            decimal porcentagem = RetornaPorcentagemImpostoRenda(anosAplicacao);
            
            return CalculaPorcentagemIR(lucroBruto, porcentagem);
         }

        private decimal RetornaPorcentagemImpostoRenda(double anos)
        {
            if (anos < 12)
                return 22.5M;
            else if (anos <= 24)
                return 18.5M;
            
            return 15M;
        }

        private int CalculaIntervaloDatasAplicacao(DateTime dataAplicacao, DateTime dataRetirada)
        {

            int meses = ((dataRetirada.Year - dataAplicacao.Year) * 12) + dataRetirada.Month - dataAplicacao.Month;

            if (dataAplicacao.Day > dataRetirada.Day)
                meses--;
            else if (dataAplicacao.Day < dataRetirada.Day)
                meses++;


            return meses;
        }

        private decimal CalculaPorcentagemIR(decimal lucroBruto, decimal porcentagem)
        {
            return (lucroBruto * porcentagem) / 100;
        }
    }
}
