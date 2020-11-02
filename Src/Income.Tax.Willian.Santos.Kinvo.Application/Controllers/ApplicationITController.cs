using System.Collections.Generic;
using System.Threading.Tasks;
using Income.Tax.Willian.Santos.Kinvo.Domain.Command.Input;
using Income.Tax.Willian.Santos.Kinvo.Domain.CommandHandlers;
using Income.Tax.Willian.Santos.Kinvo.Domain.DTOs;
using Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Income.Tax.Willian.Santos.Kinvo.Application.Controllers
{
    public class ApplicationITController : Controller
    {
        private readonly ApplicationITCommandHandler _applicationITCommandHandler;
        private readonly IApplicationITQuery _applicationITQuery;

        public ApplicationITController(ApplicationITCommandHandler applicationITCommandHandler, IApplicationITQuery applicationITQuery)
        {
            _applicationITCommandHandler = applicationITCommandHandler;
            _applicationITQuery = applicationITQuery;
        }

        public async Task<ActionResult<List<ApplicationITDTO>>> QueryTable(List<ApplicationITDTO> aplication)
        {
            return await _applicationITQuery.GetAll();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<List<ApplicationITDTO>>> RescueApplication (ApplicationITDTO applicationITDTO)
        {
            try
            {
                var data = await _applicationITCommandHandler.Handle(new ApplicationITCommand(applicationITDTO.Value, applicationITDTO.ContributionTime));

                if (data.Success is true)  return RedirectToAction("QueryTable", data.Data);

                return NotFound();
            }
            catch
            {
                return View();
            }
        }
    }
}
