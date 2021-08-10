using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aliquota.Application.Features.Investments.DTOs;
using Aliquota.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Aliquota.Application.Features.Investments.Queries
{
    public class GetInvestmentByIdQuery : IRequest<InvestmentDTO>
    {
        public decimal Id { get; set; }

        public class GetInvestmentByIdQueryHandler : IRequestHandler<GetInvestmentByIdQuery, InvestmentDTO>
        {
            private readonly IInvestmentRepository _investmentRepository;
            private readonly IMapper _mapper;

            public GetInvestmentByIdQueryHandler(IInvestmentRepository investmentRepository, IMapper mapper)
            {
                _investmentRepository = investmentRepository;
                _mapper = mapper;
            }

            public async Task<InvestmentDTO> Handle(GetInvestmentByIdQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<InvestmentDTO>(await _investmentRepository.GetByIdAsync(request.Id));
            }
        }
    }
}