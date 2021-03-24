using Aliquota.Domain.Api.ViewModel;
using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Api.Services
{
    public class Operacao
    {
        public static ResultResgate Resgate(Tipo tipo, int meses,decimal valorAplcado, decimal porcentagem)
        {
            //Chama determinada função dependendo do Tipo da Aplicação
            return tipo switch
            {
                Tipo.Mensal => Aplicacao.Mensal(meses, valorAplcado, porcentagem),
                Tipo.Semestral => Aplicacao.Semestral(meses, valorAplcado, porcentagem),
                Tipo.Anual => Aplicacao.Anual(meses, valorAplcado, porcentagem),
                _ => throw new InvalidOperationException("Tipo não encontrado"),
            };
        }
    }
}
