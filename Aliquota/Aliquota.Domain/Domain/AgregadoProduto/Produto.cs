using Aliquota.Domain.Domain.AgregadoResgate;
using Aliquota.Domain.Events;
using Aliquota.Domain.Exceptions;
using Aliquota.Domain.SeedofWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Domain.AgregadoProduto
{
    public class Produto : Entity
    {
        public Produto(string guid, string descricao, DateTime dataAplicacao, decimal precoCompra, decimal rentabilidade, decimal saldoAtual)
        {
            Guid = guid;
            Descricao = descricao;
            DataAplicacao = dataAplicacao;
            PrecoCompra = precoCompra;
            Rentabilidade = rentabilidade;
            SaldoAtual = saldoAtual;
        }

        public string Guid { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAplicacao { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal Rentabilidade { get; set; }
        public decimal SaldoAtual { get; private set; }

        public Resgate ResgatarRendimentos(decimal valor, DateTime data)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException("O valor de resgate não pode ser igual o menor que zero!");
            if (DataAplicacao >= data)
                throw new ArgumentOutOfRangeException("A data de resgate é menor ou igual a data da aplicação!");
            if (valor > SaldoAtual)
                throw new SaldoInsuficienteException();

            SaldoAtual -= valor;

            return Resgate.Create(this, data, valor);

        }

        public static Produto Create(string descricao, DateTime data, decimal precoCompra, decimal rentabilidade, decimal saldoAtual)
        {

            return new Produto(System.Guid.NewGuid().ToString(), descricao, data, precoCompra, rentabilidade, saldoAtual);
        }


    }
}
