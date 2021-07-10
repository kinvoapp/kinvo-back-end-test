using System;

namespace Aliquota.Domain.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public decimal ApplicationValue { get; set; }
        public decimal? WithdrawValue { get; set; }
        public virtual Client Client { get; set; }
        public int ClientId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime? WithdrawDate { get; set; }
        public bool IsActive { get; set; }
        

        public Application()
        {
            
        }
    
    }
}