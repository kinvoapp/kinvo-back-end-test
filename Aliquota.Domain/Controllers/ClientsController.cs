using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Domain.Models;

namespace Aliquota.Domain.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {

            List<Client> list = new List<Client>();
            list.Add( new Client { clientId = 1, clientName = "Leonam Sousa"} );
            list.Add(new Client { clientId = 2, clientName = "Fenrir Sousa" });
            return View(list);
        }
    }
}
