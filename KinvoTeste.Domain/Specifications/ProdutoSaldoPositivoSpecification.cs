using DomainValidation;
using KinvoTeste.Data;
using KinvoTeste.Models;
using System.Linq;

namespace KinvoTeste.Domain.Specifications
{
    public class ProdutoSaldoPositivoSpecification : ISpecification<Produto>
    {
        private UsuarioRepository UsuarioRepository { get; set; }

        public ProdutoSaldoPositivoSpecification()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        public bool IsSatisfiedBy(Produto entity)
        {
            var usuario = UsuarioRepository.Get(entity.Usuario.Id);
            return usuario != null && usuario.Contas.FirstOrDefault().Saldo >= entity.ValorInvestido;
        }
    }
}
