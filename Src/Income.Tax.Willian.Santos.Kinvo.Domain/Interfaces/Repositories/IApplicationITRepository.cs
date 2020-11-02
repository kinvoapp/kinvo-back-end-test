using Income.Tax.Willian.Santos.Kinvo.Domain.Entities;
using Income.Tax.Willian.Santos.Kinvo.Shared.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Repositories
{
    public interface IApplicationITRepository: IRepository<ApplicationIT>
    {

        Task<List<ApplicationIT>> GetApplication();

        Task IncludeApplication (ApplicationIT application);
    }
}
