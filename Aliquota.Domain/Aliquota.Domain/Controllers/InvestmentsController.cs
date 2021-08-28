using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Data;

namespace Aliquota.Domain.Controllers
{
    public class InvestmentsController : Controller
    {
        private readonly AliquotaDomainContext _aliquotaContext;
        public InvestmentsController(AliquotaDomainContext context)
        {
            _aliquotaContext = context;
        }
        public IActionResult Main()
        {
            return View();
        }
    }
}
