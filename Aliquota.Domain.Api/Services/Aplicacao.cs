using Aliquota.Domain.Api.ViewModel;
using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Api.Services
{
    public class Aplicacao
    {
        //Aplicação Mensal - Porcentagem aplicada cada mes
        public static ResultResgate Mensal(int meses, decimal valorAplicado, decimal porcentagem)
        {
            decimal ir = ImpostoRenda.Aplicar(meses);

            decimal lucroBruto = 0;
            for (int i = 0; i < meses; i++)
            {
                lucroBruto += (valorAplicado / 100) * porcentagem;
            }
            var iR = (lucroBruto / 100) * ir;
            var lucroLiquido = lucroBruto - iR;
            var totalReagate = valorAplicado + lucroLiquido;
            return new ResultResgate() { LucroBruto=lucroBruto, IR=iR, LucroLiquido=lucroLiquido, TotalReagate=totalReagate  };
        }

        //Aplicação Semestral - Porcentagem aplicada cada 6 meses
        public static ResultResgate Semestral(int meses, decimal valorAplicado, decimal porcentagem)
        {
            decimal ir = ImpostoRenda.Aplicar(meses);

            int semestres = (int)meses / 6;
            decimal lucroBruto = 0;
            for (int i = 0; i < semestres; i++)
            {
                lucroBruto += (valorAplicado / 100) * porcentagem;
            }
            var iR = (lucroBruto / 100) * ir;
            var lucroLiquido = lucroBruto - iR;
            var totalReagate = valorAplicado + lucroLiquido;
            return new ResultResgate() { LucroBruto = lucroBruto, IR = iR, LucroLiquido = lucroLiquido, TotalReagate = totalReagate };
        }

        //Aplicação Semestral - Porcentagem aplicada cada 1 ano
        public static ResultResgate Anual(int meses, decimal valorAplicado, decimal porcentagem)
        {
            decimal ir = ImpostoRenda.Aplicar(meses);

            int anos = (int)meses / 12;
            decimal lucroBruto = 0;
            for (int i = 0; i < anos; i++)
            {
                lucroBruto += (valorAplicado / 100) * porcentagem;
            }
            var iR = (lucroBruto / 100) * ir ;
            var lucroLiquido = lucroBruto - iR;
            var totalReagate = valorAplicado + lucroLiquido;
            return new ResultResgate() { LucroBruto = lucroBruto, IR = iR, LucroLiquido = lucroLiquido, TotalReagate = totalReagate };
        }
        
    }
}
