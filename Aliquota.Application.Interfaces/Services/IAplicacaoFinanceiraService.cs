using Aliquota.Application.Interfaces.Services.Standard;
using Aliquota.Domain;
using Aliquota.Domain.DTOs;
using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Aliquota.Application.Interfaces.Services
{
    public interface IAplicacaoFinanceiraService : IServiceBase<AplicacaoFinanceira>
    {
        Resultado<List<AplicacaoFinanceira>> ObterTodos();
        Resultado<AplicacaoFinanceira> ObterPorId(int id);
        Resultado<string> Cadastrar(AplicacaoFinanceiraDTO aplicacaoFinanceiraDTO);
        Resultado<AplicacaoFinanceira> ResgatarAplicacao(int id);

        AplicacaoFinanceira CalcularRendimento(AplicacaoFinanceira aplicacao);
        double CalcularAliquotaIR(DateTime dataAplicacao, DateTime dataResgate);
        double CalcularRendimentoBruto(AplicacaoFinanceira aplicacaoDto);
        double CalcularImpostoDeRendaRecolhido(AplicacaoFinanceira aplicacao, double aliquota);
    }
}
