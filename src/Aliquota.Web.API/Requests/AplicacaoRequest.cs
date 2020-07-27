using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.API.Requests
{
    public class AplicacaoRequest
    {
        public decimal Valor { get; set; }

        public DateTime Data { get; set; }
    }
}
