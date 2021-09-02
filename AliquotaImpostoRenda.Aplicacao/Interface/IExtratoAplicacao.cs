using AliquotaImpostoRenda.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AliquotaImpostoRenda.Aplicacao.Interface
{
    public interface IExtratoAplicacao
    {
        Task<List<ExtratoDTO>> ListarExtratos();
        void GravarExtrato(ExtratoDTO extrato);
        double DiferencaData(DateTime dataInicial, DateTime dataFinal);
        double VerificarPorcentagem(double AnosDiferenca);
        double CalcularValorParaPagar(ExtratoDTO extrato);
    }
}
