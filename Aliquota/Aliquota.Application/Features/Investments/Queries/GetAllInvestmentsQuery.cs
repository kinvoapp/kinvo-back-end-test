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
    public class GetAllInvestmentsQuery : IRequest<IEnumerable<InvestmentDTO>>
    {
        public class GetAllInvestmentsQueryHandler : IRequestHandler<GetAllInvestmentsQuery, IEnumerable<InvestmentDTO>>
        {
            private readonly IInvestmentRepository _investmentRepository;
            private readonly IMapper _mapper;

            public GetAllInvestmentsQueryHandler(IInvestmentRepository investmentRepository, IMapper mapper)
            {
                _investmentRepository = investmentRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<InvestmentDTO>> Handle(GetAllInvestmentsQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<IEnumerable<InvestmentDTO>>(await _investmentRepository.GetAllAsync());
            }
        }
    }
}
