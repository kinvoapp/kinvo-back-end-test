using System;
using System.Threading;
using System.Threading.Tasks;
using Aliquota.Application.Exceptions;
using Aliquota.Application.Features.FinancialProducts.DTO;
using Aliquota.Application.Features.Investments.DTOs;
using Aliquota.Application.Interfaces.Repositories;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Enums;
using AutoMapper;
using MediatR;

namespace Aliquota.Application.Features.Investments.Commands
{
    public class CreateWithdrawInvestmentCommand : IRequest<WithdrawDTO>
    {
        public decimal Id { get; set; }
        public DateTime WithdrawDate { get; set; }

        public class CreateWithdrawInvestmentCommandHandler : IRequestHandler<CreateWithdrawInvestmentCommand, WithdrawDTO>
        {
            private readonly IInvestmentRepository _investmentRepository;
            private readonly IWithdrawRepository _withdrawRepository;
            private readonly IMapper _mapper;

            public CreateWithdrawInvestmentCommandHandler(IInvestmentRepository investmentRepository, IMapper mapper, IWithdrawRepository withdrawRepository)
            {
                _investmentRepository = investmentRepository;
                _withdrawRepository = withdrawRepository;
                _mapper = mapper;
            }

            public async Task<WithdrawDTO> Handle(CreateWithdrawInvestmentCommand request, CancellationToken cancellationToken)
            {

                var inv = await _investmentRepository.GetByIdAsync(request.Id);
                
                
                if (inv == null) throw new ApiException("Investment not found!");

                var withdraw = CreateWithdraw(inv, request.WithdrawDate);

                await _investmentRepository.DeleteAsync(inv);

                await _withdrawRepository.AddAsync(_mapper.Map<Withdraw>(withdraw));

                return withdraw;
            }

            private WithdrawDTO CreateWithdraw(Investment inv, DateTime withdrawDate)
            {
                var investedTime = (decimal)(withdrawDate - inv.Start).TotalDays;
                var taxPercentage = GetTaxPercentage(investedTime);
                
                var withdraw = new WithdrawDTO
                {
                    TaxPercentage = taxPercentage,
                    Profit = inv.Profit,
                    TaxAmount = inv.Profit * taxPercentage,
                    LiquidIncome = inv.Profit - (inv.Profit * taxPercentage),
                    Start = inv.Start,
                    InvestedTime = investedTime,
                    FinancialProduct = _mapper.Map<FinancialProductDTO>(inv.FinancialProduct)
                };

                return withdraw;
            }

            private decimal GetTaxPercentage(decimal investedTime)
            {
                if (investedTime <= Year.ONEYEAR)
                    return 0.225M;
                if (investedTime > Year.ONEYEAR && investedTime <= Year.TWOYEARS)
                    return 0.185M;
                else
                    return 0.15M; ;
            }
        }
    }
}
