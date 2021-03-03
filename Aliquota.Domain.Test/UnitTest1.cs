using System;
using Xunit;
using Aliquota.Domain.Web;

namespace Aliquota.Domain.Test
{
  public class UnitTest1
  {
    Class1 classe1 = new Class1();
    DateTime dataTeste = new DateTime(2020, 1, 1);
    //DateTime agora = DateTime.Now;
    //DateTime anoPassado = new DateTime(agora.Year-1, ag);
    Aplicacao aplicacao = new Aplicacao(dataAplicacao: new DateTime(2020, 1, 1), quantia: 3000M);

    [Fact]
    public void Test1()
    {
      Assert.Equal(3000M, aplicacao.quantia);
    }

    [Fact]
    public void Test2()
    {
      Assert.Equal(dataTeste, aplicacao.dataAplicacao);
    }
  }
}
