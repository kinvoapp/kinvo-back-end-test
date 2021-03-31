using Aliquota.Domain.Data.Interfaces;
using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Data
{
    public class ProdutoFinanceiroRepository : GenericRepository<ProdutoFinanceiro>, IProdutoFinanceiroRepository
    {
        public ProdutoFinanceiroRepository(AliquotaContext context) : base(context)
        {

        }    
    }
}
