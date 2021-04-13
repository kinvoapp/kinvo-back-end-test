using System;
using Aliquota.Domain.Services;
using Aliquota.Domain.Model;
using Aliquota.Domain.Repository;
using System.Linq;

namespace Aliquota.Domain.Controller
{
    
    public class ProgramController 
    {
        IOperationCaller operationCaller;

        public ProgramController()
        {

            IOperationCreator operationCreator = new OperationRepository();
            operationCaller = new OperationCaller(operationCreator);
        }

        public float[] Apply(string clientCPF, string amount, string dateTime)
        {
            float amoutFloat;
            float.TryParse(amount, out amoutFloat);
            if (!clientCPF.All(char.IsDigit)) return null;
            if (clientCPF.Length != 11) return null;

            DateTime time = Convert.ToDateTime(dateTime);
            if (time == null) return null;

            //long CPF = long.Parse(clientCPF);

            FeedBack f = operationCaller.CreateOperation(clientCPF, OperationType.Application, time, amoutFloat);
            return f != null? f.values : null;
        }
        public float[] Withdraw(string clientCPF, string dateTime)
        {
            if (!clientCPF.All(char.IsDigit)) return null;
            if (clientCPF.Length != 11) return null;

            DateTime time = Convert.ToDateTime(dateTime);
            //long CPF = long.Parse(clientCPF);
            FeedBack f = operationCaller.CreateOperation(clientCPF, OperationType.Withdraw, time);
            return f != null ? f.values : null;
        }
    }
}
