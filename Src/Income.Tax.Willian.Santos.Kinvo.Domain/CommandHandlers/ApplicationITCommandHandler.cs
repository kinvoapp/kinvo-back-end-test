
using Income.Tax.Willian.Santos.Kinvo.Domain.Command.Input;
using Income.Tax.Willian.Santos.Kinvo.Domain.DTOs;
using Income.Tax.Willian.Santos.Kinvo.Domain.Entities;
using Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Repositories;
using Income.Tax.Willian.Santos.Kinvo.Domain.Interfaces.Services;
using Income.Tax.Willian.Santos.Kinvo.Shared.Commands;
using Income.Tax.Willian.Santos.Kinvo.Shared.Handlers.Interfaces;
using System;
using System.Threading.Tasks;

namespace Income.Tax.Willian.Santos.Kinvo.Domain.CommandHandlers
{
    public class ApplicationITCommandHandler: IHandler<ApplicationITCommand>
    {
        private readonly ICalculateAliquotITService _calculateAliquotITService;
        private readonly IApplicationITRepository _applicationITRepository;
        public ApplicationITCommandHandler(ICalculateAliquotITService calculateAliquotITService, IApplicationITRepository applicationITRepository)
        {
            _calculateAliquotITService = calculateAliquotITService;
            _applicationITRepository = applicationITRepository;
        }

        public async Task<GenericCommandResult> Handle(ApplicationITCommand command)
        {
            command.Validate();

            if(command.Invalid) return new GenericCommandResult(false, "Valores de entrada invalidos", new { });


            ApplicationIT application = new ApplicationIT();

            application =  _calculateAliquotITService.GetTimeAction(application);

            application = _calculateAliquotITService.GetFullProfitWithCompostInterest(application);

            application = _calculateAliquotITService.GetApplicationInterest(application);

            ApplicationITDTO data = new ApplicationITDTO(application.Value, application.ContributionTime, DateTime.Now, application?.Interest?.ProfitWithInterest);

            await _applicationITRepository.Include(application);

            //Possibilidade de retornar lista 
            //List<ApplicationIT> GetAllapplication = await _applicationITRepository.GetAll();

            return new GenericCommandResult(true, "Valores calculados, resgate concluido com sucesso! ", data);
        }
    }
}
