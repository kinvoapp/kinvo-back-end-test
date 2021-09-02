using AliquotaImpostoRenda.Dominio.DTO;
using AliquotaImpostoRenda.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AliquotaImpostoRenda.Dados.Interface
{
    public interface IExtratoRepositorio
    {
        List<ExtratoDTO> ListarExtrato();
        void GravarExtrato(ExtratoAplicacao extrato);
    }
}
