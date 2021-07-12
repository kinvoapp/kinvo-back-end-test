using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Aliquota.Domain.Entities
{
    public class Portfolio : EntityBase
    {
        public Portfolio() : base() { }

        public Guid OwnerId { get; set; }

        public User Owner { get; set; }

        public double Balance { get; set; }

        public List<Investment> Investments { get; set; }
    }
}