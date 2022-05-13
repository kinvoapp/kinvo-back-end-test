using AutoMapper;
using Kinvo.Aliquota.Domain.Entities.IncomeApplications;
using Kinvo.Aliquota.Models.Attributes;
using Kinvo.Aliquota.Models.DateIncomeApplications;
using Kinvo.Aliquota.Models.DateWithdrawals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinvo.Aliquota.Domain.Entities.Clients;
using Kinvo.Aliquota.Domain.Entities.Products;

namespace Kinvo.Aliquota.Models.IncomeApplications
{
    [AutoMap(typeof(IncomeApplication))]
    public class IncomeApplicationRequest
    {
        public Client Client { get; set; }
        
        public Product Product { get; set; }

        [Searchable]
        public long AppliedValue { get; set; }

        /*public List<DateIncomeApplicationRequest> DateIncomeApplication { get; set; }

        public List<DateWithdrawalRequest> DateWithdrawal { get; set; }*/
    }
}
