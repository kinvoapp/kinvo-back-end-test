using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Interfaces
{
    public interface IAplicacaoFinanceiraRepository
    {
        void Add(AplicacaoFinanceira obj);
        AplicacaoFinanceira GetById(int id);
        IEnumerable<AplicacaoFinanceira> GetAll();
        void Update(AplicacaoFinanceira obj);
        void Remove(AplicacaoFinanceira obj);
        void Dispose();
    }
}
