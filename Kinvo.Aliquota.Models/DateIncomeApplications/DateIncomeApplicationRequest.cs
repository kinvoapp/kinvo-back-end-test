using AutoMapper;
using Kinvo.Aliquota.Domain.Entities.DateIncomeApplications;
using Kinvo.Aliquota.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Models.DateIncomeApplications
{
    [AutoMap(typeof(DateIncomeApplication))]
    public class DateIncomeApplicationRequest
    {
        [Searchable]
        public long AppliedValue { get; set; }
        public bool Active { get; set; }
    }
}
