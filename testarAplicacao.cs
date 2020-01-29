using System;
using Xunit;


namespace Aliquota.Domain.Test
{
 
    public class TestarAplicacao
    {
       Aplicacao Obj = new Aplicacao().Criar(0, "teste", 10000, "01/01/2000");
        
       
        [Theory]

        [InlineData("01/01/1999")]
        [InlineData("01/01/2001")]
        [InlineData("01/01/2000")]
     
        public void DataFinalMenorQueInicial(String data)
        {
            Boolean resultado = Obj.Resgatar(data, Obj);
            Assert.True(resultado);
            

        }

       [Fact]

       public void ValorAplicacaoMenorQueZero()
        {

           Boolean resultado= Obj.SetValor(-1);
            
            Assert.True(resultado);
        }

        [Fact]

        public void ValorAplicacaoIgualZero()
        {

            Boolean resultado = Obj.SetValor(0);

            Assert.True(resultado);
        }
    }
}
