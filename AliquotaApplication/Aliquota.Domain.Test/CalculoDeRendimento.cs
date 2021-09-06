using System;
using System.IO;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class CalculoDeRendimento
    {
        [Fact]
        public void TestandoCalculoDeRendimentoComAteUmAnoDeAplicacao()
        {
            
            CalcularAliquota c = new CalcularAliquota();

            Assert.Equal(1038.75M, c.CalcularRendimento(1000,365));
           

        }
        [Fact]
        public void TestandoCalculoDeRendimentoDeUmADoisAnosDeAplicacao()
        {
            CalcularAliquota c = new CalcularAliquota();

            Assert.Equal(1081.5M, c.CalcularRendimento(1000, 730));

        }

        [Fact]
        public void TestandoCalculoDeRendimentoComMaisDeDoisAnosDeAplicacao()
        {
            CalcularAliquota c = new CalcularAliquota();

            Assert.Equal(1255M, c.CalcularRendimento(1000, 731));
        }
    }
}

/*Assert.Throws<System.ArgumentException>(
                () => c.GetCadastro()
            );*/