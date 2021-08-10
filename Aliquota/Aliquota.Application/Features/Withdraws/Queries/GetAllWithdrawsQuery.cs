using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aliquota.Application.Features.Investments.DTOs;
using Aliquota.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Aliquota.Application.Features.Withdraws.Queries
{
    public class GetAllWithdrawsQuery : IRequest<IEnumerable<WithdrawDTO>>
    { 
        public class GetAllWithdrawsQueryHandler : IRequestHandler<GetAllWithdrawsQuery, IEnumerable<WithdrawDTO>>
        {
            private readonly IWithdrawRepository _withdrawRepository;
            private readonly IMapper _mapper;

            public GetAllWithdrawsQueryHandler(IWithdrawRepository withdrawRepository, IMapper mapper)
            {
                _withdrawRepository = withdrawRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<WithdrawDTO>> Handle(GetAllWithdrawsQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<IEnumerable<WithdrawDTO>>(await _withdrawRepository.GetAllAsync());
            }
        }
    }
}
