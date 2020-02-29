using Aliquota.Domain.Domain.AgregadoProduto;
using Aliquota.Domain.ImpostoRenda;
using Aliquota.Domain.SeedofWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Domain.AgregadoResgate
{
    public class Resgate : Entity, IImpostoRenda
    {
        public Resgate(Produto produto, string gUID, DateTime data, decimal valor)
        {
            Produto = produto;
            GUID = gUID;
            Data = data;
            Valor = valor;
            PercentualIR = 0.00M;
            ValorIR = 0.00M;
        }

        public Produto Produto { get; set; }
        public string GUID { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public decimal PercentualIR { get; set; }
        public decimal ValorIR { get; set; }

        public static Resgate Create(Produto produto, DateTime data, decimal valor)
        {
            return new Resgate(produto, System.Guid.NewGuid().ToString(), data, valor);
        }

        public decimal Lucro()
        {
            return Produto.SaldoAtual - Produto.PrecoCompra; 
        }

        public TimeSpan PeriodoInvestimento()
        {
            return  this.Data.Subtract(Produto.DataAplicacao);
        }
    }
}
