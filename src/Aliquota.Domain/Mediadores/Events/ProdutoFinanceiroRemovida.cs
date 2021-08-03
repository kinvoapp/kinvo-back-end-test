using Aliquota.Domain.Entidades;
using MediatR;

namespace Aliquota.Domain.Mediadores.Events
{
    public class ProdutoFinanceiroRemovida : INotification
    {
        public ProdutoFinanceiro Entidade { get; set; }
    }
}