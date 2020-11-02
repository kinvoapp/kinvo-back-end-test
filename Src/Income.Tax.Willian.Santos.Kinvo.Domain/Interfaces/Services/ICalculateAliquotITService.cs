
using Income.Tax.Willian.Santos.Kinvo.Domain.Entities;

namespace Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Services
{
    public interface ICalculateAliquotITService
    {
        ApplicationIT GetTimeAction(ApplicationIT aplication);

        ApplicationIT GetFullProfitWithCompostInterest(ApplicationIT application);

        ApplicationIT GetApplicationInterest(ApplicationIT application);
    }
}
