using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities
{
    public class Resgate
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public decimal ValorBruto { get; set; }

        public decimal ValorLiquido { get; set; }

        public decimal ImpostoRendaRecolhido { get; set; }

        public Guid AplicacaoId { get; set; }

        public Aplicacao Aplicacao { get; set; }

        private void CalcularValorLiquido()
        {
            ValorLiquido = Math.Round(ValorBruto - ImpostoRendaRecolhido, 2);
        }

        private Resgate() {
            Id = Guid.NewGuid();
        }

        public static Resgate Criar(DateTime data, decimal valorBruto, decimal impostoRendaRecolhido)
        {
            var resgate = new Resgate();
            resgate.Data = data;
            resgate.ValorBruto = valorBruto;
            resgate.ImpostoRendaRecolhido = Math.Round(impostoRendaRecolhido, 2);
            resgate.CalcularValorLiquido();

            return resgate;
        }
    }
}
