using Aliquota.Data.Entity;
using Aliquota.Domain.DTO;

namespace Aliquota.Domain.Service.Interface
{
    public interface IApplicationService
    {
        Application Apply(decimal applicationValue, long clientId);
        ApplicationDTO Withdraw(ApplicationDTO application);
        ApplicationDTO GetByCode(string applicationCode);
    }
}