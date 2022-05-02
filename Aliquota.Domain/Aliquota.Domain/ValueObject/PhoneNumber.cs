using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.ValueObjects
{
    public class PhoneNumber
    {
        public string _PhoneNumber { get; set; }

        public PhoneNumber(string phoneNumber)
        {
            _PhoneNumber = phoneNumber;
        }
    }
}
