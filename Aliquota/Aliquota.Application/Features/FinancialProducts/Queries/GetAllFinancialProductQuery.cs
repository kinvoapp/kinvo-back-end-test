using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aliquota.Application.Features.FinancialProducts.DTO;
using Aliquota.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Aliquota.Application.Features.FinancialProducts.Queries
{
    public class GetAllFinancialProductQuery : IRequest<IEnumerable<FinancialProductDTO>>
    {
        public class GetAllFinancialProductQueryHandler : IRequestHandler<GetAllFinancialProductQuery, IEnumerable<FinancialProductDTO>>
        {
            private readonly IFinancialProductRepository _financialProduct;
            private readonly IMapper _mapper;

            public GetAllFinancialProductQueryHandler(IFinancialProductRepository financialProduct, IMapper mapper)
            {
                _financialProduct = financialProduct;
                _mapper = mapper;
            }

            public async Task<IEnumerable<FinancialProductDTO>> Handle(GetAllFinancialProductQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<IEnumerable<FinancialProductDTO>>(await _financialProduct.GetAllAsync());
            }
        }
    }
}
