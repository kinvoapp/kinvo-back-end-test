using Aliquota.Domain.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AliquotaContext _context;
        public IAplicacaoRepository Aplicacoes { get; }

        public IProdutoFinanceiroRepository Produtos { get; }

        public UnitOfWork(AliquotaContext aliquotaDbContext,
            IAplicacaoRepository aplicacaoRepository,
            IProdutoFinanceiroRepository produtoRepository)
        {
            this._context = aliquotaDbContext;
            this.Aplicacoes = aplicacaoRepository;
            this.Produtos = produtoRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
