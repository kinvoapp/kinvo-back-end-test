using System;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces.Repositories;

namespace Aliquota.Data.Repositories
{
    public class AplicacaoRFRepository: RepositoryBase<AplicacaoRF>, IAplicacaoRFRepository
    {
        public AplicacaoRFRepository(IServiceProvider pServicePorvider): base(pServicePorvider){  

            
                      
        }



    }
}