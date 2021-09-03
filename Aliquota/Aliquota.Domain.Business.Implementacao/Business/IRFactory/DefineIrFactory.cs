using Aliquota.Domain.Business.Implementacao.Business.IRStrategy;
using Aliquota.Domain.Entities.Entidades;
using Aliquota.Domin.Util.Excecoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Business.Implementacao.Business.IRFactory
{
    public static class DefineIrFactory
    {
        public static IImpostoRendaStrategy create(Produto produto)
        {
            if (produto.DataResgate.HasValue)
            {
                if (produto.DataResgate.Value.Subtract(produto.DataInvestimento).TotalDays < 366)
                {
                    return new IR1anoStrategy(produto.ValorAtual.Value, produto.ValorInvestido.Value);
                }
                else if (produto.DataResgate.Value.Subtract(produto.DataInvestimento).TotalDays < 731)
                {
                    return new IRde1Ate2anosStrategy(produto.ValorAtual.Value, produto.ValorInvestido.Value);
                }
                else
                {
                    return new IRMaior2anosStrategy(produto.ValorAtual.Value, produto.ValorInvestido.Value);
                }
            }
            throw new BusinessException(@"Não foi possivel definir imposto de renda");
        }
    }
}
