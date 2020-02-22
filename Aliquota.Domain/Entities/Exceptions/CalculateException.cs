using System;

namespace Aliquota.Domain.Entities.Exceptions
{
    public class CalculateException : ApplicationException
    {
        public CalculateException(string message) : base(message)
        {
        }
    }
}
