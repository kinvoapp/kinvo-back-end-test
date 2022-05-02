using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.ValueObjects
{
    public class Email
    {
        public string _email { get; set; }

        public Email(string email)
        {
            _email = email;
        }
    }
}
