using AliquotaImpostoRenda.Aplicacao.Interface;
using AliquotaImpostoRenda.Dados.Interface;
using AliquotaImpostoRenda.Dominio;
using AliquotaImpostoRenda.Dominio.DTO;
using AliquotaImpostoRenda.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AliquotaImpostoRenda.Aplicacao
{
    public class ExtratoAplicacao : IExtratoAplicacao
    {
        private readonly IClienteAplicacao _clienteAplicacao;
        private readonly IExtratoRepositorio _extratoRepositorio;

        public ExtratoAplicacao(IExtratoRepositorio extratoRepositorio, IClienteAplicacao clienteAplicacao)
        {
            _clienteAplicacao = clienteAplicacao;
            _extratoRepositorio = extratoRepositorio;
        }
        public void GravarExtrato(ExtratoDTO extrato)
        {
            if (string.IsNullOrEmpty(extrato.Cliente.Nome))
                throw new Exception("Obrigatório Nome do Cliente");

            ValidacaoObrigatorio(extrato);
            try
            {
                var cliente = _clienteAplicacao.BuscarCliente(extrato.Cliente.Nome);
                if (cliente != null)
                    extrato.ClienteId = cliente.Id;
                else
                    extrato.ClienteId = _clienteAplicacao.GravarCliente(extrato.Cliente.Nome);

                _extratoRepositorio.GravarExtrato(extrato.MapearExtrato(extrato));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ExtratoDTO>> ListarExtratos() => _extratoRepositorio.ListarExtrato();        

        public double DiferencaData(DateTime dataInicial, DateTime dataFinal)
        {
            var totalDias = (dataFinal - dataInicial).TotalDays;
            return ((totalDias > 0)? Math.Round((totalDias / 365), 1, MidpointRounding.ToEven) : (1));
        }

        public double VerificarPorcentagem(double AnosDiferenca)
        {
            double porcentagem;
            if(AnosDiferenca <= Constantes.TEMPOATEUMANO)
            {
                porcentagem = Constantes.VALORATEUMANO;
            }else if(AnosDiferenca <= Constantes.TEMPOENTREUMANODOISANOS)
            {
                porcentagem = Constantes.VALORENTREUMANOADOISANOS;
            }
            else
            {
                porcentagem = Constantes.VALORACIMADEDOISANOS;
            }

            return porcentagem;
        }

        public double CalcularValorParaPagar(ExtratoDTO extrato)
        {
            ValidacaoObrigatorio(extrato);

            double saldoPagar;
            if(extrato.TipoEntradaLucro == eTipoEntradaLucro.Porcentagem)
            {
                saldoPagar = extrato.ValorResgatado * (extrato.PorcentagemLucro / 100);
            }
            else
            {
                saldoPagar = extrato.PorcentagemLucro;
            }

            return saldoPagar * (extrato.PorcentagemPagamento / 100);
        }

        private void ValidacaoObrigatorio(ExtratoDTO extrato)
        {
            if (extrato.ValorResgatado <= 0.0)
                throw new Exception(Constantes.MENSAGEMERROVALORRESGATE);

            if (extrato.DataResgate < extrato.DataAplicacao)
                throw new Exception(Constantes.MENSAGEMERRODATARESGATEMENORAPLICACAO);
        }
    }
}
