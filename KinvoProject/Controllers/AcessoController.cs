using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinvoProject.Controllers
{
    public class AcessoController : Controller
    {
        public string AcessUser()
        {
            string conta = HttpContext.Session.GetString(ContaController.SessionKeyConta);
            if (conta != null)
            {
                return conta;
            }
            else
            {
                conta = null;
                return conta;
            }
        }



        public bool AcessAdmin()
        {
            string admin = HttpContext.Session.GetString(BancoController.SessionKeyConta);
            if (admin != null)
            {
                return true;
            }
            else
            {
                
                return false;
            }
        }
    }
}
