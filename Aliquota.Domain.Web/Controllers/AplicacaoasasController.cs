using Aliquota.Domain.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Web.Controllers
{
  [Route("aplicacao")]
  public class AplicacaoasasController : Controller
  {
    private readonly AplicacaoDataContexts _db;
    public AplicacaoasasController(AplicacaoDataContexts db)
    {
      _db = db;
    }
    [Route("")]
    public IActionResult Index()
    {
      var aplicacoes = _db.Aplicacoes.OrderByDescending(x => x.Id).Take(5).ToArray();

      return View(aplicacoes);
    }

    [HttpPost, Route("create")]
    public IActionResult Create(Aplicacao aplicacao)
    {
      if (!ModelState.IsValid)
        return View();

      //aplicacao.Author = User.Identity.Name;
      //aplicacao.Posted = DateTime.Now;
      //aplicacao.Juros = 12;
      
      _db.Aplicacoes.Add(aplicacao);
      _db.SaveChanges();

      return View();

      //return RedirectToAction("Post", "Blog", new
      //{
      //  year = aplicacao.Posted.Year,
      //  month = aplicacao.Posted.Month,
      //  key = aplicacao.Key
      //});
    }

  }
}
