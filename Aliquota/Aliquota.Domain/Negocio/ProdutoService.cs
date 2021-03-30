using Aliquota.Domain.Data.Interfaces;
using Aliquota.Domain.Models;
using Aliquota.Domain.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Negocio
{
    public class ProdutoService : IProdutoService
    {
        IUnitOfWork _unitOfWork;

        public ProdutoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(ProdutoFinanceiro item)
        {
            item.Id = Guid.NewGuid();

            _unitOfWork.Produtos.Add(item);
            _unitOfWork.Complete();
        }

        public void Edit(ProdutoFinanceiro item)
        {
            _unitOfWork.Produtos.Update(item);
            _unitOfWork.Complete();
        }

        public Task<ProdutoFinanceiro> Find(Guid id)
        {
            return _unitOfWork.Produtos.Get(id);
        }

        public Task<IEnumerable<ProdutoFinanceiro>> List()
        {
            return _unitOfWork.Produtos.GetAll();
        }

        public void Remove(ProdutoFinanceiro item)
        {
            _unitOfWork.Produtos.Delete(item);
            _unitOfWork.Complete();
        }
    }
}
