using Income.Tax.Willian.Santos.Kinvo.Domain.DTOs;
using Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Queries;
using Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Income.Tax.Willian.Santos.Kinvo.Infra.Data.Queries
{
    public class ApplicationITQuery : IApplicationITQuery
    {
        private readonly IApplicationITRepository _applicationITRepository;

        public ApplicationITQuery(IApplicationITRepository applicationITRepository)
        {
            _applicationITRepository = applicationITRepository;
        }

        //Por falta do banco real, foi necessário obter os dados pela própria EF<ApplicationITDTO>, já que os dados estão em memória.

        // Isto pois, a camada query está relacionada ao DTO que se relaciona com a camada alta do projeto.
        public async Task<List<ApplicationITDTO>> GetAll()
        {
            var data = await _applicationITRepository.GetAll();

            var result = new List<ApplicationITDTO>();

            data?.ForEach(x => {
                
                var entity = new ApplicationITDTO(x.Value,x.ContributionTime, DateTime.Now, x.Interest.ProfitWithInterest);

                result.Add(entity);

                entity = null;
            });

            return result;
        }
    }
}
