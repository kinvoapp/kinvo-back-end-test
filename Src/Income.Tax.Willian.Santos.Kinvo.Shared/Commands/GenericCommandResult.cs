using Income.Tax.Willian.Santos.Kinvo.Shared.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Income.Tax.Willian.Santos.Kinvo.Shared.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; private set; }

        public string Message { get; private set; }

        public object Data { get; private set; }
    }
}
