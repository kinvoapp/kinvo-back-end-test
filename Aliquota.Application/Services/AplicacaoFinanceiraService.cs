using Aliquota.Application.Interfaces.Services;
using Aliquota.Application.Services.Standard;
using Aliquota.Domain;
using Aliquota.Domain.DTOs;
using Aliquota.Domain.Entities;
using Aliquota.Infraestructure.Interfaces.Repositories.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Application.Services
{
    public class AplicacaoFinanceiraService : ServiceBase<AplicacaoFinanceira>, IAplicacaoFinanceiraService
    {
        public AplicacaoFinanceiraService(IAplicacaoFinanceiraRepository repository) : base(repository) { }

        public Resultado<List<AplicacaoFinanceira>> ObterTodos()
        {
            var lista = base.GetAll();
            if (!lista.Any())
                return Resultado<List<AplicacaoFinanceira>>.Erro("Nenhum registro encontrado.");

            return Resultado<List<AplicacaoFinanceira>>.OK(lista.ToList());
        }

        public Resultado<AplicacaoFinanceira> ObterPorId(int id)
        {
            var aplicacao = base.GetById(id);
            if (aplicacao == null)
                return Resultado<AplicacaoFinanceira>.Erro("Aplicação não encontrada.");

            return Resultado<AplicacaoFinanceira>.OK(aplicacao);
        }

        public Resultado<string> Cadastrar(AplicacaoFinanceiraDTO aplicacaoFinanceiraDTO)
        {
            var mensagemErro = Validar(aplicacaoFinanceiraDTO);
            if (!string.IsNullOrEmpty(mensagemErro))
                return Resultado<string>.Erro(mensagemErro);

            var aplicacaoFinanceira = aplicacaoFinanceiraDTO.ConverterDtoParaEntity();
            repository.Add(aplicacaoFinanceira);

            return Resultado<string>.OK("Cadastro efetuado com sucesso");
        }

        public string Validar(AplicacaoFinanceiraDTO aplicacaoFinanceiraDTO)
        {
            if (aplicacaoFinanceiraDTO == null)
                return "Request body é obrigatório.";

            var mensagemErro = "";

            if (string.IsNullOrEmpty(aplicacaoFinanceiraDTO.Nome))
                mensagemErro += $"O campo '{nameof(aplicacaoFinanceiraDTO.Nome)}' é obrigatório.\n";
            if (aplicacaoFinanceiraDTO.ValorAplicado <= 0)
                mensagemErro += $"O campo '{nameof(aplicacaoFinanceiraDTO.ValorAplicado)}' não pode ser igual ou menor que zero.\n";
            if (aplicacaoFinanceiraDTO.TaxaRendimento <= 0)
                mensagemErro += $"O campo '{nameof(aplicacaoFinanceiraDTO.TaxaRendimento)}' não pode ser igual ou menor que zero.\n";
            if (aplicacaoFinanceiraDTO.DataAplicacao == DateTime.MinValue)
                mensagemErro += $"O campo '{nameof(aplicacaoFinanceiraDTO.DataAplicacao)}' é obrigatório.";

            return mensagemErro;
        }

        public Resultado<AplicacaoFinanceira> ResgatarAplicacao(int id)
        {
            var aplicacao = GetById(id);
            if (aplicacao == null)
                return Resultado<AplicacaoFinanceira>.Erro("Aplicação não encontrada.");
            if (aplicacao.DataResgate.HasValue)
                return Resultado<AplicacaoFinanceira>.Erro("Aplicação já resgatada.");

            aplicacao.DataResgate = DateTime.Now;

            var mensagemErro = ValidarResgate(aplicacao.DataAplicacao, aplicacao.DataResgate.Value);
            if (!string.IsNullOrEmpty(mensagemErro))
                return Resultado<AplicacaoFinanceira>.Erro(mensagemErro);

            aplicacao = CalcularRendimento(aplicacao);
            base.Update(aplicacao);

            return Resultado<AplicacaoFinanceira>.OK(aplicacao);
        }

        private string ValidarResgate(DateTime dataAplicacao, DateTime dataResgate)
        {
            return dataAplicacao.Date >= dataResgate.Date ? "A data de resgate não pode ser menor que a data de aplicação" : "";
        }

        public AplicacaoFinanceira CalcularRendimento(AplicacaoFinanceira aplicacao)
        {
            var aliquota = CalcularAliquotaIR(aplicacao.DataAplicacao, aplicacao.DataResgate.Value);
            aplicacao.ValorRendimentoBruto = CalcularRendimentoBruto(aplicacao);
            aplicacao.ValorImpostoDeRendaRecolhido = CalcularImpostoDeRendaRecolhido(aplicacao, aliquota);

            return aplicacao;
        }

        public double CalcularAliquotaIR(DateTime dataAplicacao, DateTime dataResgate)
        {
            var tempoInvestido = dataResgate.Date - dataAplicacao.Date;
            if (Math.Abs(tempoInvestido.Days) < Constantes.DIAS_ANO)
                return Constantes.ALIQUOTA_ATE_UM_ANO;
            else if (Math.Abs(tempoInvestido.Days) < (Constantes.DIAS_ANO * 2))
                return Constantes.ALIQUOTA_ENTRE_UM_E_DOIS_ANOS;
            else
                return Constantes.ALIQUOTA_ACIMA_DE_DOIS_ANOS;
        }

        public double CalcularRendimentoBruto(AplicacaoFinanceira aplicacao)
        {
            var tempoInvestido = aplicacao.DataResgate.Value.Date - aplicacao.DataAplicacao.Date;
            var valor = (double)aplicacao.ValorAplicado * Math.Pow((double)(1 + (aplicacao.TaxaRendimento / 100 / Constantes.DIAS_ANO)), tempoInvestido.Days);
            return Math.Round(valor, 2);
        }

        public double CalcularImpostoDeRendaRecolhido(AplicacaoFinanceira aplicacao, double aliquota)
        {
            var valor = (aplicacao.ValorRendimentoBruto - (double)aplicacao.ValorAplicado) * aliquota;
            return Math.Round(valor.Value, 2);
        }
    }
}
