using System;
using System.Linq;
using Aliquota.Domain.Services;
using Aliquota.Domain.Model;
using Microsoft.EntityFrameworkCore;


namespace Aliquota.Domain.Repository
{

    public class OperationRepository :
        IOperationCreator,
        IOperationReader<Operation>
    {
        //OperationDB dataBase = new OperationDB();

        public FeedBack AssemblyOperation(string clientCPF, OperationType operationType
            , DateTime dateTime, float amount = 0)
        {
            switch (operationType) 
            {
                case OperationType.Application:
                    return ApplicationOperation(clientCPF, amount, dateTime);
                case OperationType.Withdraw:
                    return WithdrawOperation(clientCPF, dateTime);
                default:
                    throw new NotImplementedException();
            }
        }

        FeedBack ApplicationOperation(string clientCPF, float amount, DateTime dateTime)
        {
            using (var dataBase = new OperationDB())
            {
                dataBase.Add(new Operation(dateTime, clientCPF, amount, OperationType.Application));
                dataBase.SaveChanges();
                FeedBack feedBack = new FeedBack(amount);
                return feedBack;
            }
        }
        FeedBack WithdrawOperation(string client, DateTime dateTime)
        {
            using (var dataBase = new OperationDB())
            {
                FeedBack fb = CalCulateRemainingMoney(client, dateTime);
                if (fb == null) return fb;

                dataBase.Add(new Operation(dateTime, client, fb.values[0] + fb.values[1], OperationType.Withdraw));
                return fb;
            }
        }
        FeedBack CalCulateRemainingMoney(string client, DateTime dateTime)
        {
            using (var dataBase = new OperationDB())
            {

                Operation[] applications = FindOperations(client, OperationType.Application, dateTime);

                applications = (from application in applications where application.withdrawn == false select application).ToArray();

                if (applications.Length == 0) return null;

                float TotalIR = 0;
                float profit = 0;

                foreach (Operation o in applications)
                {
                    //if (o.withdrawn == true) continue;
                    float amount = o.amount;
                    float totalProfit = 0;
                    int days = dateTime.Day - o.dateTime.Day;
                    int months = dateTime.Month - o.dateTime.Month;
                    int years = dateTime.Year - o.dateTime.Year;

                    if (days < 0 && months > 0) months -= 1;
                    if (months < 0 && years > 0) years -= 1;

                    int totalMonths = (12 * years) + months;

                    for (int i = 0; i < totalMonths; i++)
                    {
                        totalProfit += (amount * o.profitPerMonth);
                        amount += (amount * o.profitPerMonth);
                    }

                    float totalProfitWithoutIR = totalProfit;

                    if (years <= 1 && months <= 0) totalProfit -= totalProfit * .225f;
                    else if ((years == 2 && months <= 0) || years < 2) totalProfit -= totalProfit * .185f;
                    else totalProfit -= totalProfit * .15f;
                    TotalIR += totalProfitWithoutIR - totalProfit;
                    profit += totalProfit;
                    dataBase.Operations.Remove(o);

                }

                dataBase.SaveChanges();
                return new FeedBack(profit, TotalIR, profit + TotalIR) ;
            }
        }
        public Operation[] FindOperations(string client, OperationType operationType, DateTime currentDate)
        {
            using (var dataBase = new OperationDB())
            {
                return (from operations in dataBase.Operations
                        where (operations.clientCPF == client
                        && operations.operationType == operationType
                        && DateTime.Compare(operations.dateTime, currentDate) < 0)
                        select operations).ToArray();
            }
        }
    }

}
