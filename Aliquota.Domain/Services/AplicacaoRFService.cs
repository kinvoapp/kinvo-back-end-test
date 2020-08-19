using Aliquota.Domain.Entities;
using Aliquota.Domain.Interfaces.Repositories;
using Aliquota.Domain.Interfaces.Services;

namespace Aliquota.Domain.Services
{
    public class AplicacaoRFService: ServiceBase<AplicacaoRF>, IAplicacaoRFService
    {
        private readonly IAplicacaoRFRepository _aplicacaoRFRepository;

        public AplicacaoRFService(IAplicacaoRFRepository pAplicacaoRepository):base(pAplicacaoRepository)
        {
            _aplicacaoRFRepository = pAplicacaoRepository;
        }
    }
}