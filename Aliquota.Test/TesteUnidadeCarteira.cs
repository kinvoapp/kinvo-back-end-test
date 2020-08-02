using System;
using Aliquota.Domain.Model;
using Xunit;
namespace Aliquota.Test
{
    public class TesteUnidadeCarteira
    {
        
        public TesteUnidadeCarteira()
        {

        }
        [Fact]
        public void TesteCriarCarteiraNomeVazio()
        {
            Assert.Throws<ArgumentNullException>(() => new Carteira(""));
        }
    }
}
