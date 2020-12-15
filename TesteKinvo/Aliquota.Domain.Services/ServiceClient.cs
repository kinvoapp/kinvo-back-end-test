using Aliquota.Domain.Core.Interfaces.Repositorys;
using Aliquota.Domain.Core.Interfaces.Services;
using Aliquota.Domain.Entitys;

namespace Aliquota.Domain.Services
{
    public class ServiceClient : ServiceBase<Client>, IServiceClient
    {
        private readonly IRepositoryClient repositoryClient;

        public ServiceClient(IRepositoryClient repositoryClient)
            :base(repositoryClient)
        {
            this.repositoryClient = repositoryClient;
        }
    }
}
