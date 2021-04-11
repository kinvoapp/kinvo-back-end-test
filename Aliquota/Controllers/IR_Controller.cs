using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Controllers
{
    public class IR_Controller : Controller
    {
        // GET: IR_Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: IR_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IR_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IR_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IR_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IR_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IR_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IR_Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
