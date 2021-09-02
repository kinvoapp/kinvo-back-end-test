using AliquotaImpostoRenda.Dados.Interface;
using AliquotaImpostoRenda.Data.Context;
using AliquotaImpostoRenda.Dominio.DTO;
using AliquotaImpostoRenda.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliquotaImpostoRenda.Dados.Repositorio
{
    public class ExtratoRepositorio : IExtratoRepositorio
    {
        public ExtratoRepositorio(){}

        public void GravarExtrato(ExtratoAplicacao extrato)
        {
            extrato.Cliente = null;
            using (var db = new AliquotaImpostoRendaContext())
            {
                db.ExtratoAplicacao.Add(extrato);
                db.SaveChanges();
            }
        }

        public List<ExtratoDTO> ListarExtrato()
        {
            using (var db = new AliquotaImpostoRendaContext())
            {
                return db.ExtratoAplicacao.Select(e => new ExtratoDTO
                {
                    Cliente = new ClienteDTO
                    {
                        Nome = e.Cliente.Nome
                    },
                    ClienteId = e.ClienteId,
                    Createad = e.Createad,
                    DataAplicacao = e.DataAplicacao,
                    DataResgate = e.DataResgate,
                    PorcentagemLucro = e.PorcentagemLucro,
                    PorcentagemPagamento = e.PorcentagemPagamento,
                    TipoEntradaLucro = e.TipoEntradaLucro,
                    ValorResgatado = e.ValorResgatado,
                    ValorParaPagarImposto = e.ValorParaPagarImposto
                }).ToList();
            }
        }
    }
}
