using Aliquota.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Domain.DTO
{
    public class ResponseApplicationDTO
    {
        public int ClientId { get; set; }
        public decimal ApplicationValue { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool IsActive { get; set; }

        public static explicit operator ResponseApplicationDTO(Application application)
        {
            return new ResponseApplicationDTO()
            {
                ClientId = application.ClientId,
                ApplicationValue = application.ApplicationValue,
                ApplicationDate = application.ApplicationDate,
                IsActive = application.IsActive
            };
        }
    }
}
