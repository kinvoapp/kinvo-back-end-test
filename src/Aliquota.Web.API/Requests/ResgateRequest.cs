using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.API.Requests
{
    public class ResgateRequest
    {
        [Required(ErrorMessage = "Necessario informar a data de resgate")]
        public DateTime Data { get; set; }
    }
}
