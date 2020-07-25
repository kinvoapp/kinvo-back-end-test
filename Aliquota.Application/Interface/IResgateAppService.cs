using Aliquota.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Application.Interface
{
    public interface IResgateAppService
    {
        Task<decimal> Handle(Guid aplicacaoId);
    }
}
