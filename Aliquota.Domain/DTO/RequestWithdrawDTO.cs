using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.DTO
{
    public class RequestWithdrawDTO
    {
        public int ApplicationId { get; set; }
        public DateTime WithdrawDate { get; set; }
    }
}
