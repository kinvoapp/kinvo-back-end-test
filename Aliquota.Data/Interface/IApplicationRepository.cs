using Aliquota.Data.Entity;

namespace Aliquota.Data.Interface
{
    public interface IApplicationRepository
    {
        Application Apply(Application application);
        Application Withdraw(long id, decimal withdrawValue);
        Application GetByCode(string code);
    }
}