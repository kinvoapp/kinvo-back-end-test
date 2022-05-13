using AutoMapper;
using Kinvo.Aliquota.Domain.Entities.DateWithdrawals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Models.DateWithdrawals
{
    [AutoMap(typeof(DateWithdrawal))]
    public class DateWithdrawalResponse
    {
        public Guid Uuid { get; set; }
        public long WithdrawalValue { get; set; }
        public bool Ativo { get; set; }
    }
}
