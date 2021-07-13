using Aliquota.Domain.DTO;
using Aliquota.Domain.Entities;

namespace Aliquota.Domain.Interfaces
{
    public interface IAliquotRepository
    {
        Application GetApplication(int id);
        Application Apply(Application application);
        Application Withdraw(Application application);


    }
}
