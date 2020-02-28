using Aliquota.Domain.Domain.AgregadoProduto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Events
{
    public class RendimentoResgatadoDomainEvent:INotification
    {
        public RendimentoResgatadoDomainEvent(Produto produto, decimal valor, DateTime data)
        {
            Produto = produto;
            Valor = valor;
            Data = data;
        }

        public Produto Produto { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
