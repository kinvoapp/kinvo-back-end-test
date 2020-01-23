using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Services
{
    public interface IAliquotaService
    {
        Aplicacao DoAplicar(Produto produto, Cliente cliente, DateTime data, decimal valor);
        void DoResgatar(Aplicacao aplicacao, DateTime data);
        decimal DoCalcularIR(DateTime dataI, DateTime dataF, decimal baseIR);
    }
}
