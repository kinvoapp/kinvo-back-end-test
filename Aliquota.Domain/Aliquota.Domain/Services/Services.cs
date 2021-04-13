using System;
using System.Collections.Generic;
using System.Text;
using Aliquota.Domain.Model;


namespace Aliquota.Domain.Services
{
    public interface IOperationCaller
    {
        //void CreateOperation(string clientName, float amount, OperationType operationType);
        FeedBack CreateOperation(string clientCPF, OperationType operationType, DateTime dateTime, float amount = 0);
    }
    //Repositories *-----------------------------------------------------------------
    public interface IOperationReader<T>
    {
        T[] FindOperations(string client, OperationType operationType, DateTime dateTime);
    }
    //Factories *---------------------------------------------------------------------
    public interface IOperationCreator
    {
        FeedBack AssemblyOperation(string client, OperationType operationType, DateTime dateTime, float amount = 0);
    }

    public class FeedBack
    {
        public float[] values;

        public FeedBack(params float[] values)
        {
            this.values = values;
        }
    }
}
