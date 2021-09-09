using Aliquota.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Produto Add(Produto produto);
        IList<Produto> GetAll();
        Produto GetById(int produtoId);
        Produto Update(int produtoId, Produto produto);
        void Delete(Produto produto);
    }

    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AliquotaContext context) : base(context)
        {
        }

        public Produto Add(Produto produto)
        {
            this.dbSets.Add(produto);
            SaveChanges();
            return produto;
        }

        public IList<Produto> GetAll() => this.dbSets.ToList();

        public Produto GetById(int produtoId)
            => this.dbSets
                        .Include(p => p.Investimentos)
                        .Where(p => p.Id == produtoId)
                        .SingleOrDefault();

        public Produto Update(int produtoId, Produto produtoNovo)
        {
            var produtoDB = GetById(produtoId);

            if (produtoDB is null)
            {
                throw new ArgumentNullException("Produto não encontrato no banco de dados");
            }

            produtoDB.Update(produtoNovo);
            SaveChanges();
            
            return produtoDB;
        }

        public void Delete(Produto produto)
        {
            var produtoDB = this.dbSets
                                    .Include(p => p.Investimentos)
                                    .Where(p => p.Id == produto.Id)
                                    .SingleOrDefault();

            var qtdInvestimento = produtoDB.Investimentos.Count;

            if (qtdInvestimento != 0)
            {
                var msg = "Não é permitido excluir produtos financeiros vinculados a investimentos";
                throw new InvalidOperationException(msg);
            }

            this.dbSets.Remove(produto);
            SaveChanges();
        }

        private void SaveChanges() => this.context.SaveChanges();
    }
}
