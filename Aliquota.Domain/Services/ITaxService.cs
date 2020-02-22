using System;

namespace Aliquota.Domain.Services
{
    public interface ITaxService
    {
        double Tax(TimeSpan timeSpan);
    }
}
