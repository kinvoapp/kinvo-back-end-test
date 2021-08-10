using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aliquota.Application.Exceptions;
using Aliquota.Application.Features.Investments.DTOs;
using Aliquota.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Aliquota.Application.Features.Withdraws.Queries
{
    public class GetWithdrawByIdQuery : IRequest<WithdrawDTO>
    {
        public decimal Id { get; set; }

        public class GetWithdrawByIdQueryHandler : IRequestHandler<GetWithdrawByIdQuery, WithdrawDTO>
        {
            private readonly IWithdrawRepository _withdrawRepository;
            private readonly IMapper _mapper;

            public GetWithdrawByIdQueryHandler(IWithdrawRepository withdrawRepository, IMapper mapper)
            {
                _withdrawRepository = withdrawRepository;
                _mapper = mapper;
            }

            public async Task<WithdrawDTO> Handle(GetWithdrawByIdQuery request, CancellationToken cancellationToken)
            {
                var withdraw = await _withdrawRepository.GetByIdAsync(request.Id);
                if (withdraw == null) throw new ApiException("Withdraw not found");

                return _mapper.Map<WithdrawDTO>(withdraw);
            }
        }
    }
}