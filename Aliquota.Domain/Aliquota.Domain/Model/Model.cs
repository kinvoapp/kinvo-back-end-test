using System;
using Aliquota.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Aliquota.Domain.Model
{

    public class OperationCaller : IOperationCaller
    {
        IOperationCreator operationCreator;

        public OperationCaller(IOperationCreator operationCreator)
        {
            this.operationCreator = operationCreator;
        }

        public FeedBack CreateOperation(string clientCPF, OperationType operationType, DateTime dateTime, float amount)
        {
            switch (operationType) 
            {
                case OperationType.Application:
                    return CreateApplication(clientCPF, amount, dateTime);
                case OperationType.Withdraw:
                    return CreateWithdraw(clientCPF, amount, dateTime);
                default:
                    throw new NotImplementedException();

            }
        }

        public FeedBack CreateApplication(string clientCPF, float amount, DateTime dateTime)
        {

            if (amount <= 0) 
            {
                return null;
            }
            return operationCreator.AssemblyOperation(clientCPF,
                   OperationType.Application, dateTime, amount);

        }
        public FeedBack CreateWithdraw(string clientCPF, float amount, DateTime dateTime)
        {
            return operationCreator.AssemblyOperation(clientCPF,
                   OperationType.Withdraw, dateTime, amount);
        }
    }
}
