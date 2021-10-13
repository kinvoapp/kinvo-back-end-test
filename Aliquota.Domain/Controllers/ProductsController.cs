using Aliquota.Domain.Models;
using Aliquota.Domain.Models.ViewsModels;
using Aliquota.Domain.Services;
using Aliquota.Domain.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductService _productService;
        private readonly ClientService _clientService;

        public ProductsController(ProductService productService, ClientService clientService)
        {
            _productService = productService;
            _clientService = clientService;
        }
        public IActionResult Index()
        {
            var list = _productService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var clients = _clientService.FindAll();
            var viewModel = new ProductFormViewModel { Clients = clients };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            _productService.Insert(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? _id)
        {
            if (_id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _productService.FindById(_id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(int _id)
        {
            _productService.Remove(_id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? _id)
        {
            if (_id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _productService.FindById(_id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? _id)
        {
            if (_id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _productService.FindById(_id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Client> clients = _clientService.FindAll();
            ProductFormViewModel viewModel = new ProductFormViewModel { Product = obj, Clients = clients};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int _id, Product product)
        {
            if (_id != product.productId)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            try
            {
                _productService.Update(product);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public IActionResult Error (string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
