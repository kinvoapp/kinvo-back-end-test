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
            if (precoCompra <= 0.00M)
                throw new PrecoOutOfRangeException();
            PrecoCompra = precoCompra;
            Rentabilidade = rentabilidade;
            SaldoAtual = saldoAtual;
            Disponibilizar();
        }

        public string Guid { get; set; }
        public string Descricao { get; set; }
        public Situacao Situacao { get; private set; }
        public DateTime DataAplicacao { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal Rentabilidade { get; set; }
        public decimal SaldoAtual { get; private set; }

        public Resgate ResgatarRendimentos(decimal valor, DateTime data)
        {
            if (VerificarSituacaoParaResgate())
            {
                if (valor <= 0)
                    throw new ValorResgateMenorIgualZeroException();
                if (DataAplicacao > data)
                    throw new DataResgateMenorDataAplicacaoException();
                if (valor > SaldoAtual)
                    throw new SaldoInsuficienteException();

                SaldoAtual -= valor;

                if (SaldoAtual == 0.00M)
                    Resgatar();

                return Resgate.Create(this, data, valor);
            }

            return null;

        }
        public void Disponibilizar()
        {
            Situacao = Situacao.Disponivel;
        }

        public void Resgatar()
        {
            Situacao = Situacao.Resgatado;
        }
        private bool VerificarSituacaoParaResgate()
        {
            if (Situacao != Situacao.Disponivel)
                throw new ProdutoIndisponivelParaResgateException();
            return true;
        }

        public static Produto Create(string descricao, DateTime data, decimal precoCompra, decimal rentabilidade, decimal saldoAtual)
        {

            return new Produto(System.Guid.NewGuid().ToString(), descricao, data, precoCompra, rentabilidade, saldoAtual);
        }


    }
}
