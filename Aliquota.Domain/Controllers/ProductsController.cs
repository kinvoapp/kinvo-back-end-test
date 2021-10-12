using Aliquota.Domain.Models;
using Aliquota.Domain.Models.ViewsModels;
using Aliquota.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    }
}
