using Aliquota.Domain.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class IR_Record
    {
        [Key]
        public int recordId { get; set; }
        public DateTime recordDate { get; set; }
        public double recordAmount { get; set; }
        public IR_Status recordStatus { get; set; }
        public Client Client { get; set; }

        public IR_Record()
        {
        }

        public IR_Record(int recordId, DateTime date, double amount, IR_Status recordStatus, Client client)
        {
            this.recordId = recordId;
            this.recordDate = date;
            this.recordAmount = amount;
            this.recordStatus = recordStatus;
            Client = client;
        }
    }
}
