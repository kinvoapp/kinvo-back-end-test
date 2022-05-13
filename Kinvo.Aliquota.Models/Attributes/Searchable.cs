﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Searchable : Attribute
    {
        public string CustomName { get; set; }
    }
}
