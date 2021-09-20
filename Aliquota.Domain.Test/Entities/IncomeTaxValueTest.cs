using System;
using Aliquota.Domain.Entities;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class IncomeTaxValueTest
    {
        [Fact(DisplayName = "Teste Cálculo com menos de um ano de aplicação")]
        public void LessThanAYear()
        {
            Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddMonths(1));
            IncomeTaxValue _tax = new IncomeTaxValue();
            _tax.Calculo(_product);
            var expected = true;
            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste Cálculo com um ano de aplicação")]
        public void EqualThanAYear()
        {
            Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddYears(1));
            IncomeTaxValue _tax = new IncomeTaxValue();
            _tax.Calculo(_product);
            var expected = true;
            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste Cálculo com dois anos de aplicação")]
        public void EqualThanATwoYear()
        {
            Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddYears(2));
            IncomeTaxValue _tax = new IncomeTaxValue();
            _tax.Calculo(_product);
            var expected = true;
            Assert.Equal(expected, _product.Valid);
        }
        [Fact(DisplayName = "Teste Cálculo com mais de dois anos de aplicação")]
        public void EqualLOrMoreThanATwoYear()
        {
            Product _product = new Product("EGIE3", 300, DateTime.Now, DateTime.Now.AddYears(3));
            IncomeTaxValue _tax = new IncomeTaxValue();
            _tax.Calculo(_product);
            var expected = true;
            Assert.Equal(expected, _product.Valid);
        }
    }
}
