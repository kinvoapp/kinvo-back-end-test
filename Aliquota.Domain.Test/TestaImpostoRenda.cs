using System;
using Xunit;
using Aliquota.Domain;

namespace Aliquota.Domain.Test
{
  public class TestaImpostoRenda
  {
    DateTime inicio = new DateTime(2019, 1, 1);
    [Fact]
    public void MenosDeAno()
    {
      DateTime antesAno = new DateTime(2019, 12, 31);
      Assert.Equal(22.5M, ImpostoRenda.CalculaTaxaJuros(inicio, antesAno));
    }
    [Fact]
    public void UmAno()
    {
      DateTime umAno = new DateTime(2020, 1, 1);
      Assert.Equal(18.5M, ImpostoRenda.CalculaTaxaJuros(inicio, umAno));
    }
    [Fact]
    public void DoisAnos()
    { 
      DateTime doisAnos = new DateTime(2021, 1, 1);
      Assert.Equal(15M, ImpostoRenda.CalculaTaxaJuros(inicio, doisAnos));
    }
  }
}
