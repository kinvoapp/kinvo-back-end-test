using System;

namespace Aliquota.Domain.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
