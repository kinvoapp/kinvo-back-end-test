using Aliquota.Domain.ControllersGatewaysAndPresenters.Adapters;
using Aliquota.Domain.Entities.Models;
namespace Aliquota.Domain.UseCases.ProductMovement
{
    internal static class Verify
    {

        public static bool DoesUserHasEnoughtFunds(User user, FinanceProduct product, decimal amount, IDatabaseAdapter database)
        {
            var wallet = database.GetFinanceProductWallet(user, product);
            return wallet.Amount >= amount;
        }
    }
}
