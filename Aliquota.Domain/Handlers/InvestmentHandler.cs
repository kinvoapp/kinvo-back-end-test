using Aliquota.Domain.Commands;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Exceptions;

namespace Aliquota.Domain.Handlers {    
    public class InvestmentHandler {
        public Investment CreateInvestment(CreateInvestmentCommand command, Portfolio portfolio) {
            if(command.Value <= 0) {
                throw new HandlerException("O valor da aplicação deve ser maior que 0");
            }

            if(command.Value > portfolio.Balance) {
                throw new HandlerException("Você não tem saldo suficiente disponível para essa operação");
            }

            return new Investment();
        }
    }
}