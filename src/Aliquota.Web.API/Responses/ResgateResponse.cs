using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.API.Responses
{
    public class ResgateResponse
    {
        public DateTime Data { get; set; }

        public decimal ValorBruto { get; set; }

        public decimal ValorLiquido { get; set; }

        public decimal ImpostoRendaRecolhido { get; set; }

        public static ResgateResponse Criar(Resgate resgate) => new ResgateResponse()
        {
            Data = resgate.Data,
            ValorBruto = resgate.ValorBruto,
            ValorLiquido = resgate.ValorLiquido,
            ImpostoRendaRecolhido = resgate.ImpostoRendaRecolhido,
        };
    }
}
