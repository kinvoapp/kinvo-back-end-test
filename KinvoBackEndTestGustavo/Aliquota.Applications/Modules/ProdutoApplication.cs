using Aliquota.Applications.Shared;
using Aliquota.Domain.ProdutoModule;
using Aliquota.Domain.Shared;
using System.Collections.Generic;

namespace Aliquota.Applications.Modules
{
    public class ProdutoApplication : ApplicationBase<Produto>
    {
        private readonly IRepository<Produto> ProdutoRepository;

        public ProdutoApplication(IRepository<Produto> produtoRepository)
        {
            ProdutoRepository = produtoRepository;
        }        

        public override bool AddEntidade(Produto produto)
        {
            bool resultado = ProdutoRepository.InserirNovo(produto);
            return resultado;
        }

        public override List<Produto> SelecionarTodasEntidades()
        {
            List<Produto> produtos = ProdutoRepository.SelecionartTodos();
            return produtos;
        }

        public override Produto SelecionarEntidadePorId(int id)
        {
            Produto produto = ProdutoRepository.SelecionarPorId(id);
            return produto;
        }

        public override bool EditarEntidade(int id, Produto entidade)
        {
            throw new System.NotImplementedException();
        }
    }
}
