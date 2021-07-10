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

        public List<Investment> Investments { get; set; }

        [NotMapped]
        public int TotalApplied => Investments.Select(v => v.Value).Aggregate((acc, v) => acc + v);
    }
}