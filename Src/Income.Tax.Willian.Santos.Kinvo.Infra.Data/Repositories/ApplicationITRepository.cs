
using Income.Tax.Willian.Santos.Kinvo.Domain.Entities;
using Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Repositories;
using Income.Tax.Willian.Santos.Kinvo.Infra.Data.DataContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Income.Tax.Willian.Santos.Kinvo.Infra.Data.Repositories
{
    public class ApplicationITRepository : ApplicationITRepository<ApplicationIT>, IApplicationITRepository
    {
        private readonly ApplicationITDataContext _applicationITDataContext;

        public ApplicationITRepository (ApplicationITDataContext applicationITDataContext)
        {
            _applicationITDataContext = applicationITDataContext;
        }

        public async Task<List<ApplicationIT>> GetApplication()
        {
           return await  _applicationITDataContext.ToListAsync();
        }

        public async Task IncludeApplication(ApplicationIT application)
        {
            _applicationITDataContext.Add(application);
            await SaveChages();
        }
    }
}
