using Aliquota.Domain.Business.IBusiness;
using Aliquota.Domain.Business.Implementacao.Base;
using Aliquota.Domain.Entities.DTO;
using Aliquota.Domain.Entities.Entidades;
using Aliquota.Domain.Repository.IRepositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.Implementacao.Business
{
    public class SituacaoProdutoBusiness : BusinessCrudBase<SituacaoProduto>, ISituacaoProdutoBusiness
    {
        public SituacaoProdutoBusiness(ISituacaoProdutoRepositorio situacaoProdutoRepository)
            : base()
        {
            _repository = situacaoProdutoRepository;
        }

        public async Task Criar(SituacaoProdutoDto item)
        {
            await Add(ConverteDtoParaObj(item));
        }

        public async Task Editar(SituacaoProdutoDto item)
        {
           await Update(ConverteDtoParaObj(item));
        }

        public async Task<SituacaoProdutoDto> GetItemById(int id)
        {
            return new SituacaoProdutoDto(await GetById(id));
        }

        public async Task<List<SituacaoProdutoDto>> GetListGrid()
        {
            List<SituacaoProduto> situacaoProdutoLista = await GetAllAsync();
            var retorno = new List<SituacaoProdutoDto>();
            foreach (var item in situacaoProdutoLista)
            {
                var itemView = new SituacaoProdutoDto(item);
                retorno.Add(itemView);
            }
            return retorno;
        }
        private SituacaoProduto ConverteDtoParaObj(SituacaoProdutoDto item)
        {
            return new SituacaoProduto() { Id = item.Id, Situacao = item.Situacao};
        }
    }
}
