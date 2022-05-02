using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.ValueObjects
{
    public class CPF
    {
        public string _cpf { get; set; }

        public CPF(string cpf)
        {
            _cpf = cpf;
        }
    }
}
