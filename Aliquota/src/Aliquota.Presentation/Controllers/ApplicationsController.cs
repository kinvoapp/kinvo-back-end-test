using Aliquota.Application.Interfaces;
using Aliquota.Application.ViewModels;
using Aliquota.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Presentation.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly IContaAppService _applicationAppService;
        private readonly IContaRepository _applicationRepository;
        public ApplicationsController(IContaAppService applicationAppService,
                                        IContaRepository applicationRepository)
        {
            _applicationAppService = applicationAppService;
            _applicationRepository = applicationRepository;
        }
        public async Task<IActionResult> Index()
        {
            var applicationsViewModel = await _applicationAppService.ListContasAsync();
            return View(applicationsViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var edit = await _applicationRepository.UpdateConta(id);

            return View(edit);
        }
    }
}
