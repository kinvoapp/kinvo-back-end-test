using DomainValidation;
using KinvoTeste.Domain.Specifications;
using KinvoTeste.Models;

namespace KinvoTeste.Domain.Validations
{
    public class ProdutoAplicarValorValidation : Validator<Produto>
    {
        public ProdutoAplicarValorValidation()
        {
            var valorInvestidoPositivo = new ProdutoValorInvestidoPositivoSpecification();
            base.Add(nameof(valorInvestidoPositivo), new Rule<Produto>(valorInvestidoPositivo, "O valor da aplicação deve ser maior que 0 (zero)"));
            
            var saldoPositivo = new ProdutoSaldoPositivoSpecification();
            base.Add(nameof(saldoPositivo), new Rule<Produto>(saldoPositivo, "Saldo insuficiente para aplicação"));
        }
    }
}
