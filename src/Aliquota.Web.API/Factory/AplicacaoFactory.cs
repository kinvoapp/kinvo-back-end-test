using Aliquota.API.Requests;
using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.API.Factory
{
    public static class AplicacaoFactory
    {
        public static Aplicacao Criar(AplicacaoRequest aplicacao)
        {
            return Aplicacao.Criar(aplicacao.Valor, aplicacao.Data);
        }
    }
}
