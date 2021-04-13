using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aliquota.Domain.Utils;

namespace Aliquota.Data.Entity
{
    [Table("application")]
    public class Application
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("application_code")]
        public string ApplicationCode { get; set; }

        [Column("client_id")]
        public long ClientId { get; set; }
        
        [Column("application_date")]
        public DateTime ApplicationDate { get; set; }

        [Column("withdraw_date")]
        public DateTime? WithdrawDate { get; set; }

        [Column("application_value")]
        public decimal ApplicationValue { get; set; }

        [Column("withdraw_value")]
        public decimal WithdrawValue { get; set; }
        

        public Application()
        {
            string randomCode = Guid.NewGuid().ToString();
            ApplicationCode = randomCode;

            WithdrawValue = Constant.NeverWithdrew;
            ApplicationDate = DateTime.Now;
        }

    }
}