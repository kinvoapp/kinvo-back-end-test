using System.Threading;
using System.Threading.Tasks;
using Aliquota.Application.Exceptions;
using Aliquota.Application.Features.FinancialProducts.DTO;
using Aliquota.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Aliquota.Application.Features.FinancialProducts.Commands
{
    public class DeleteFinancialProductCommand : IRequest<FinancialProductDTO>
    {
        public decimal Id;

        public DeleteFinancialProductCommand(decimal id)
        {
            Id = id;
        }

        public class DeleteFinancialProductCommandHandler : IRequestHandler<DeleteFinancialProductCommand, FinancialProductDTO>
        {
            private readonly IFinancialProductRepository _financialProducts;
            private readonly IMapper _mapper;

            public DeleteFinancialProductCommandHandler(IFinancialProductRepository financialProducts, IMapper mapper)
            {
                _financialProducts = financialProducts;
                _mapper = mapper;
            }

            public async Task<FinancialProductDTO> Handle(DeleteFinancialProductCommand request, CancellationToken cancellationToken)
            {
                var fp = await _financialProducts.GetByIdAsync(request.Id);
                
                if (fp == null) throw new ApiException("Financial Product Not Found.");
                
                await _financialProducts.DeleteAsync(fp);

                return _mapper.Map<FinancialProductDTO>(fp);
            }
        }
    }
}
