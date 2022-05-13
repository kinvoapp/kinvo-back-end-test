using AutoMapper;
using Kinvo.Aliquota.Domain.Entities.DateIncomeApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Models.DateIncomeApplications
{
    [AutoMap(typeof(DateIncomeApplication))]
    public class DateIncomeApplicationResponse
    {
        public Guid Uuid { get; set; }
        public long AppliedValue { get; set; }
        public bool Ativo { get; set; }
    }
}
