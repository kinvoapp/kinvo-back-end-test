using Aliquota.Domain.Core.Interfaces.Repositorys;
using Aliquota.Domain.Core.Interfaces.Services;
using Aliquota.Domain.Entitys;

namespace Aliquota.Domain.Services
{
    public class ServiceFinancialApplication : ServiceBase<FinancialApplication>, IServiceFinancialApplication
    {
        private readonly IRepositoryFinancialApplication repositoryApplication;

        public ServiceFinancialApplication(IRepositoryFinancialApplication repositoryApplication)
            :base(repositoryApplication)
        {
            this.repositoryApplication = repositoryApplication;
        }
    }
}
