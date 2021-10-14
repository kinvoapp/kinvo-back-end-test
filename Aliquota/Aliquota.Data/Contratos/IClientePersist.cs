using Aliquota.Domain.Entidades;
using System;
using System.Threading.Tasks;

namespace Aliquota.Data.Contratos
{
    public interface IClientePersist
    {
        Task<Cliente[]> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task<double> Resgatar(double valorBruto, double valorInvestido, double valorResgate, double lucro, int tempoDeInvestimento, int id, ComprovanteResgate comprovante);
    }
}
