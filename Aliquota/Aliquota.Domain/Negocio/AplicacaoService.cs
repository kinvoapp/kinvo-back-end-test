using Aliquota.Domain.Data.Interfaces;
using Aliquota.Domain.Models;
using Aliquota.Domain.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.Negocio
{
    public class AplicacaoService : IAplicacaoService
    {
        IUnitOfWork _unitOfWork;

        public AplicacaoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Aplicacao item)
        {
            _unitOfWork.Aplicacoes.Add(item);
            _unitOfWork.Complete();
        }

        public void Edit(Aplicacao item)
        {
            _unitOfWork.Aplicacoes.Update(item);
            _unitOfWork.Complete();
        }

        public Task<Aplicacao> Find(Guid id)
        {
            return _unitOfWork.Aplicacoes.Get(id);
        }

        public Task<IEnumerable<Aplicacao>> List()
        {
            return _unitOfWork.Aplicacoes.GetAll();
        }

        public void Remove(Aplicacao item)
        {
            _unitOfWork.Aplicacoes.Delete(item);
            _unitOfWork.Complete();
        }
    }
}
