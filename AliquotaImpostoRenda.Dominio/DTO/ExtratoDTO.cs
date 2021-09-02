using AliquotaImpostoRenda.Dominio.Comum;
using AliquotaImpostoRenda.Dominio.Entidades;
using AliquotaImpostoRenda.Dominio.Enum;
using Newtonsoft.Json;
using System;

namespace AliquotaImpostoRenda.Dominio.DTO
{
    public class ExtratoDTO : Entidade
    {
        public DateTime DataAplicacao { get; set; }
        public DateTime DataResgate { get; set; }
        public double ValorResgatado { get; set; }
        public double ValorParaPagarImposto { get; set; }
        public eTipoEntradaLucro? TipoEntradaLucro { get; set; }
        public double PorcentagemLucro { get; set; }
        public double PorcentagemPagamento { get; set; }
        public int ClienteId { get; set; }
        public ClienteDTO Cliente { get; set; } = new ClienteDTO();

        public ExtratoAplicacao MapearExtrato(ExtratoDTO extrato)
        {
            var extratoSerialize = JsonConvert.SerializeObject(extrato);

            return JsonConvert.DeserializeObject<ExtratoAplicacao>(extratoSerialize);
        }
    }
}
