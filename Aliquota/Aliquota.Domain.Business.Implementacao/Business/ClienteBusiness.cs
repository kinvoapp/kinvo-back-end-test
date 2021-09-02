using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Business.Implementacao.Base;
using Aliquota.Domain.Entities.DTO;
using Aliquota.Domain.Entities.Entidades;
using Aliquota.Domain.Repository.IRepositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.Implementacao.Business
{
    public class ClienteBusiness : BusinessCrudBase<Cliente>, IClienteBusiness
    {
        public ClienteBusiness(IClienteRepositorio clienteRepository)
            : base()
        {
            _repository = clienteRepository;
        }

        public void Criar(ClienteDto item)
        {
            Add(ConverteDtoParaObj(item));
        }

        public void Editar(ClienteDto item)
        {
            Update(ConverteDtoParaObj(item));
        }

        public async Task<ClienteDto> GetItemById(int id)
        {
            return new ClienteDto(await GetById(id));
        }

        public async Task<List<ClienteDto>> GetListGrid()
        {
            List<Cliente> clienteLista = await GetAll();
            var retorno = new List<ClienteDto>();
            foreach (var item in clienteLista)
            {
                var itemView = new ClienteDto(item);
                retorno.Add(itemView);
            }
            return retorno;
        }
        private Cliente ConverteDtoParaObj(ClienteDto item)
        {
            return new Cliente() { Id = item.Id, NomeCliente = item.NomeCliente};
        }
    }
}
