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
        private readonly IApplicationAppService _applicationAppService;
        private readonly IApplicationRepository _applicationRepository;
        public ApplicationsController(IApplicationAppService applicationAppService,
                                        IApplicationRepository applicationRepository)
        {
            _applicationAppService = applicationAppService;
            _applicationRepository = applicationRepository;
        }
        public async Task<IActionResult> Index()
        {
            var applicationsViewModel = await _applicationAppService.ListApplicationsAsync();
            return View(applicationsViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var edit = await _applicationRepository.UpdateApplication(id);

            return View(edit);
        }
    }
}
