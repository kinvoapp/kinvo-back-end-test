using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aliquota.Application.Features.Investments.DTOs;
using Aliquota.Application.Interfaces.Repositories;
using Aliquota.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Aliquota.Application.Features.Investments.Commands
{
    public class CreateInvestmentCommand : IRequest<decimal>
    {
        public decimal Amount { get; set; }
        public DateTime Start { get; set; }
        public decimal FinancialProductId { get; set; }
        public class CreateInvestmentCommandHandler : IRequestHandler<CreateInvestmentCommand, decimal>
        {
            private readonly IInvestmentRepository _investmentRepository;
            private readonly IMapper _mapper;

            public CreateInvestmentCommandHandler(IInvestmentRepository investmentRepository, IMapper mapper)
            {
                _investmentRepository = investmentRepository;
                _mapper = mapper;
            }

            public async Task<decimal> Handle(CreateInvestmentCommand request, CancellationToken cancellationToken)
            {
                var inv = _mapper.Map<Investment>(request);

                await _investmentRepository.AddAsync(inv);

                return inv.Id;
            }
        }
    }
}
