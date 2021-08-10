using System.Threading;
using System.Threading.Tasks;
using Aliquota.Application.Features.FinancialProducts.DTO;
using Aliquota.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Enums;
using Aliquota.Application.Common.Mappings;

namespace Aliquota.Application.Features.FinancialProducts.Commands
{
    public class CreateFinancialProductCommand : IRequest<decimal>, IMapFrom<FinancialProduct>
    {
        public string Name { get; set; }
        public decimal MinimalInvestedAmount { get; set; }
        public decimal MonthlyIncome { get; set; }
        public Profitability Profitability { get; set; }
        public Deadline Deadline { get; set; }

        public class CreateFinancialProductCommandHandler : IRequestHandler<CreateFinancialProductCommand, decimal>
        {
            private readonly IFinancialProductRepository _financialProducts;
            private readonly IMapper _mapper;

            public CreateFinancialProductCommandHandler(IFinancialProductRepository financialProducts, IMapper mapper)
            {
                _financialProducts = financialProducts;
                _mapper = mapper;
            }

            public async Task<decimal> Handle(CreateFinancialProductCommand request,
                CancellationToken cancellationToken)
            {
                var fp = _mapper.Map<FinancialProduct>(request);

                await _financialProducts.AddAsync(fp);

                return fp.Id;
            }
        }
    }
}