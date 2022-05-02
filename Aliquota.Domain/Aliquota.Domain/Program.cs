using Aliquota.Domain.DataTransferObject.Entities;
using Aliquota.Domain.DataTransferObject.Entities.Client;
using Aliquota.Domain.DataTransferObject.Entities.FinancialProduct;
using Aliquota.Domain.DataTransferObject.Entities.Wallet;
using Aliquota.Domain.DataTransferObject.ProductApplication;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Factories;
using System;
using System.Collections.Generic;

namespace Aliquota
{
    class Program
    {
        List<ProductApplication> termsList = new List<ProductApplication>();


       public void Main(string[] args, List<ProductApplication> termsList)
        {
            string opcao;
            Console.WriteLine(Header());
            Console.WriteLine("Now, we need some personal Data to continue the application.");
            RequestClientInputDTO clientDTO = new RequestClientInputDTO();
            Console.WriteLine("Input your name:");
            clientDTO.Name = Console.ReadLine();
            Console.WriteLine("Input your last name:");
            clientDTO.LastName = Console.ReadLine();
            Console.WriteLine("Input your CPF:");
            clientDTO.CPF = Console.ReadLine();
            Console.WriteLine("Input your email:");
            clientDTO.Email = Console.ReadLine();
            Console.WriteLine("Input your phone number:");
            clientDTO.PhoneNumber = Console.ReadLine();

            ClientFactory clientFactory = new ClientFactory();
            var client = clientFactory.BuildNewClient(clientDTO.Name, clientDTO.LastName, clientDTO.Email, clientDTO.CPF, clientDTO.PhoneNumber);
            PressKey();
            Console.Clear();

            RequestWalletInputDTO walletDTO = new RequestWalletInputDTO();
            Console.WriteLine("How much do you want to input in your virtual wallet?");
            walletDTO.AmountMoney = Console.ReadLine();
            WalletFactory walletFactory = new WalletFactory();
            var wallet = walletFactory.BuildNewWallet(client.ClientID, walletDTO.AmountMoney);
            PressKey();
            Console.Clear();


            RequestFinancialProductInputDTO financialProductDTO = new RequestFinancialProductInputDTO();
            Console.WriteLine("Input the first name of financial product: ");
            financialProductDTO.Name = Console.ReadLine();
            Console.WriteLine("Input the second name of financial product: ");
            financialProductDTO.LastName = Console.ReadLine();
            Console.WriteLine("Input your the percentage that you want in your aplication: ");
            financialProductDTO.Percentage = Console.ReadLine();
            FinancialProductFactory financialProductFactory = new FinancialProductFactory();
            var financialProduct = financialProductFactory.BuildNewFinancialProduct(financialProductDTO.Name, financialProductDTO.LastName, financialProductDTO.Percentage);

            PressKey();
            Console.Clear();


            do
            {
                Console.WriteLine(Header());
                Console.WriteLine(Menu());
                opcao = ReadMenuOption();
                ProcessarOpcaoMenu(opcao, client, wallet, financialProduct, termsList);
                PressKey();
                Console.Clear();
            } while (opcao != "3");
        }


        static void ProcessarOpcaoMenu(string opcao, Client client, Wallet wallet, FinancialProduct financialProduct, List<ProductApplication> termsList)
        {

            switch (opcao)
            {
                case "1":
                    RequestProductApplicationInputDTO productApplicationDTO = new RequestProductApplicationInputDTO();
                    Console.WriteLine("How much do you want to input in your virtual product application?");
                    productApplicationDTO.Money = Console.ReadLine();
                    bool confirmThatHaveMoneyOnWallet = wallet.DrawClientMoney(productApplicationDTO.Money);
                    if (confirmThatHaveMoneyOnWallet)
                    {
                        ProductApplication productApplication = InsertMoneyOnApplication(client, financialProduct, productApplicationDTO.Money);
                        termsList.Add(productApplication);       
                    }
                    
                    break;
                case "2":

                    double teste = RescueApplication(termsList, financialProduct, wallet);
                    break;
                case "3":
                    Console.WriteLine("Thank you to use the program.");
                    break;
                default:
                    Console.WriteLine("Invalid menu option!");
                    break;
            }
        }
        static string Header()
        {
            return "Welcome to Kinvo Financial Institution";
        }

        static string Menu()
        {
            string menu = "Chose one Option\n" +
                            "1 - Applicate money on your Financial Product\n" +
                            "2 - Rescue money on your Financial Application\n" +
                            "3 - Exit Program \n";
            return menu;
        }
        static string ReadMenuOption()
        {
            string opcao;
            Console.Write("You chose the option: ");
            opcao = Console.ReadLine();
            return opcao;
        }
        private static void PressKey()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static ProductApplication InsertMoneyOnApplication(Client client, FinancialProduct financialProduct, string money)
        {

            ProductApplicationFactory productApplication = new ProductApplicationFactory();
            var productApplicationConstruct = productApplication.BuildNewProductApplication(client.ClientID, financialProduct.FinancialProductID, money);
            return productApplicationConstruct;

        }
        
       public static double RescueApplication(List<ProductApplication> productApplication, FinancialProduct financialProduct, Wallet wallet)
       {

            foreach (ProductApplication element in productApplication)
            {
                ProductRescueFactory rescue = new ProductRescueFactory();
                var productRescueOutput = rescue.BuildNewProductRescue(element.ProductApplicantionID);
                double profit = productRescueOutput.RescueMoneyOnApplication(element.AmountMoney.Money, financialProduct.Percentage.Percentage, element.DateApplicantion);
                wallet.InsertClientMoney(profit);
            }
            Console.WriteLine("Your money go to wallet! Now you have in your wallet: " + wallet.AmountMoney.Money);

            return wallet.AmountMoney.Money;
           
       }
    }
}
