using System.Threading;
using System.Threading.Tasks;
using Aliquota.Application.Features.FinancialProducts.DTO;
using Aliquota.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Aliquota.Application.Features.FinancialProductss.Queries
{
    public class GetFinancialProductByIdQuery : IRequest<FinancialProductDTO>
    {
        public decimal Id { get; set; }

        public GetFinancialProductByIdQuery(decimal id)
        {
            Id = id;
        }

        public class GetFinancialProductByIdQueryHandler : IRequestHandler<GetFinancialProductByIdQuery, FinancialProductDTO>
        {
            private readonly IFinancialProductRepository _financialProductRepository;
            private readonly IMapper _mapper;

            public GetFinancialProductByIdQueryHandler(IFinancialProductRepository financialProductRepository, IMapper mapper)
            {
                _financialProductRepository = financialProductRepository;
                _mapper = mapper;
            }

            public async Task<FinancialProductDTO> Handle(GetFinancialProductByIdQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<FinancialProductDTO>(await _financialProductRepository.GetByIdAsync(request.Id));
            }
        }
    }
}
