using Aliquota.Domain.ProdutoModule;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class ProdutoTestes
    {
        [Fact]
        public void ValidarProduto_PropriedadesInvalidas()
        {
            //Arrange
            Produto produto = new(0, null);

            //Action
            string resultado = produto.Validar();

            //Assert
            Assert.Equal("O nome do produto não poder ser nulo\n", resultado);
        }

        [Fact]
        public void ValidarProduto_PropriedadesValidas()
        {
            //Arrange
            Produto produto = new(0, "Nome do produto");

            //Action
            string resultado = produto.Validar();

            //Assert
            Assert.Equal("VALIDO", resultado);
        }
    }
}
