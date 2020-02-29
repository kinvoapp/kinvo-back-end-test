﻿using Aliquota.Domain.Domain.AgregadoProduto;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;
using Aliquota.Domain.Exceptions;

namespace Aliquota.Domain.Test.Domain
{
    public class ProdutoTest
    {
        private Produto produto;
        public ProdutoTest()
        {
            produto = Produto.Create("Teste", new DateTime(2019, 01, 05), 200.00M, 7.00M, 1500.00M);
        }

        [Fact]
        public void CriarProdutoComSucesso()
        {
            produto = Produto.Create("Teste", new DateTime(2019, 01, 05), 200.00M, 7.00M, 1500.00M);
        }

        [Fact]
        public void CriarProdutoPrecoZerado()
        {
            Assert.Throws<PrecoOutOfRangeException>(() => Produto.Create("Teste", new DateTime(2019, 01, 05), 0.00M, 7.00M, 1500.00M));
        }

        [Fact]
        public void CriarProdutoPrecoNegativo()
        {
            Assert.Throws<PrecoOutOfRangeException>(() => Produto.Create("Teste", new DateTime(2019, 01, 05), -200.00M, 7.00M, 1500.00M));
        }



        [Fact]
        public void ResgatarRendimentoValorMenorQueSaldo()
        {
            
            produto.ResgatarRendimentos(1000.00M, DateTime.Now);
            Assert.True(produto.SaldoAtual == 500.00M);
        }

        [Fact]
        public void ResgatarRendimentoTotal()
        {
           
            produto.ResgatarRendimentos(1500.00M, DateTime.Now);
            Assert.True(produto.SaldoAtual == 0.00M);
        }

        [Fact]
        public void ResgatarRendimentoSaldoInsuficiente()
        {
            Assert.Throws<SaldoInsuficienteException>(() => produto.ResgatarRendimentos(1600.00M, DateTime.Now));
        }

        [Fact]
        public void ResgatarRendimentoValorZerado()
        {
            
            Assert.Throws<ValorResgateMenorIgualZeroException>(() => produto.ResgatarRendimentos(0.00M, DateTime.Now));
        }

        [Fact]
        public void ResgatarRendimentoValorNegativo()
        {

            Assert.Throws<ValorResgateMenorIgualZeroException>(() => produto.ResgatarRendimentos(-100.00M, DateTime.Now));
        }

        [Fact]
        public void ResgatarRendimentoDataMenorQueDataDaAplicacao()
        {

            Assert.Throws<DataResgateMenorDataAplicacaoException>(() => produto.ResgatarRendimentos(1000.00M, new DateTime(2019, 01, 04)));
        }
    }
}
