using Aliquota.BusinessLogic.Models;


namespace ControllersGatewaysAndPresenters.Drivers
{
    public interface IDatabaseDriver
    {
        FinanceProduct GetFinanceProductFromFinanceProductMove(FinanceProductMove fromA);
        FinanceProductWallet GetFinanceProductWallet(User user, FinanceProduct financeProduct);
        User GetOwnerFromFinanceProductMove(FinanceProductMove move);
        void PromisseCreateFinanceProductMove(User user, FinanceProduct financeproduct, decimal amount);
        void CreateWalletIfNotExists(User user, FinanceProduct financeproduct);
        void PromisseAddFundsToWallet(FinanceProductWallet wallet, decimal amount);
        void FulfillAllPromisses();
        void PromisseDebitProductMove(FinanceProductMove fromA, decimal removedFromA);
        void PromisseDebitFundsToWallet(FinanceProductWallet wallet, decimal removedFromA);
    }
}
