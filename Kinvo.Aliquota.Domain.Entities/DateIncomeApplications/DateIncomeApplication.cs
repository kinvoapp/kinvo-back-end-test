using Kinvo.Aliquota.Domain.Entities.DefaultEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Entities.DateIncomeApplications
{
    public class DateIncomeApplication : DefaultEntity
    {
        [Required]
        public long AppliedValue { get; set; }


    }
}
