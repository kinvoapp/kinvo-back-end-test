using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.API.Responses
{
    public class AplicacaoResponse
    {

        public Guid Id { get; set; }

        public decimal Valor { get; set; }

        public decimal ValorCorrigido { get; set; }

        public decimal PercentualRendimentoMes { get; set; }

        public DateTime DataAplicacao { get; set; }

        public bool Resgatado { get; set; }

        public ResgateResponse Resgate { get; set; }

        public static AplicacaoResponse Criar(Aplicacao aplicacao) => new AplicacaoResponse()
        {
            Id = aplicacao.Id,
            DataAplicacao = aplicacao.Data,
            Valor = aplicacao.Valor,
            PercentualRendimentoMes = aplicacao.PercentualRendimentoMes,
            Resgatado = aplicacao.Resgate != null,
            Resgate = aplicacao.Resgate != null ? ResgateResponse.Criar(aplicacao.Resgate) : null
        };

    }
}
