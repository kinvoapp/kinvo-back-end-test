using DomainValidation;
using KinvoTeste.Models;

namespace KinvoTeste.Domain.Specifications
{
    public class ProdutoValorInvestidoPositivoSpecification : ISpecification<Produto>
    {
        public bool IsSatisfiedBy(Produto entity)
        {
            return entity.ValorInvestido > 0;
        }
    }
}
