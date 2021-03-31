using Aliquota.Domain.Data.Interfaces;
using Aliquota.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Data
{
    public class AplicacaoRepository : GenericRepository<Aplicacao>, IAplicacaoRepository
    {
        public AplicacaoRepository(AliquotaContext context) : base(context)
        {

        }
    }
}
