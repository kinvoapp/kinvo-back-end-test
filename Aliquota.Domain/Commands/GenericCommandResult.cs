using System;
using Aliquota.Domain.Commands.Contracts;

namespace Aliquota.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult()
        {
            //classe apenas para retornar um resultado generico para a tela
        }
        public GenericCommandResult(bool succes, string message, object data)
        {
            Succes = succes;
            Message = message;
            Data = data;
        }

        public bool Succes { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
