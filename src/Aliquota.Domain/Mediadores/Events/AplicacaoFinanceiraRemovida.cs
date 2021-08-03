using Aliquota.Domain.DTOs;
using MediatR;

namespace Aliquota.Domain.Mediadores.Events
{
    public class AplicacaoFinanceiraRemovida : INotification
    {
        public AplicacaoFinanceiraResgatada Entidade { get; set; }
    }
}