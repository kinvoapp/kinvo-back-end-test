using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.ValueObjects
{
    public class FullName
    {
        public string _name { get; set; }
        public string _lastName { get; set; }


        public FullName(string name, string lastName)
        {
            _name = name;
            _lastName = lastName;
        }
    }
}
