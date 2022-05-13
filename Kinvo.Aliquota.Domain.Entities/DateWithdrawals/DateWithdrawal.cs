using Kinvo.Aliquota.Domain.Entities.DefaultEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Entities.DateWithdrawals
{
    public class DateWithdrawal : DefaultEntity
    {
        [Required]
        public long WithdrawalValue { get; set; }
    }
}
