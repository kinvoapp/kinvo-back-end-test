using AutoMapper;
using Kinvo.Aliquota.Domain.Entities.DateWithdrawals;
using Kinvo.Aliquota.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Models.DateWithdrawals
{
    [AutoMap(typeof(DateWithdrawal))]
    public class DateWithdrawalRequest
    {
        [Searchable]
        public long WithdrawalValue { get; set; }
        public bool Active { get; set; }
    }
}
