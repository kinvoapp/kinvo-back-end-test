using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class ErrorList
    {
        public IEnumerable<string> Erros { get; private set; }

        public ErrorList(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
