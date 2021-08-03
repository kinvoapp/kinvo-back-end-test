using Aliquota.Domain.Entidades;
using MediatR;

namespace Aliquota.Domain.Mediadores.Events
{
    public class AplicacaoFinanceiraInserida : INotification
    {
        public AplicacaoFinanceira Entidade { get; set; }
        public bool OperacaoConcluida { get; internal set; }
    }
}