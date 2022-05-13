using Kinvo.Aliquota.Domain.Entities.DefaultEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinvo.Aliquota.Domain.Entities.Clients
{
    public class Client : DefaultEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public string Cpf { get; set; }
    }
}
