using FinancialProduct.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialProduct.Test.EntityTests;

    [TestClass]
    public class ProductTest
    {
        private readonly Product _validTodo = new Product("Titulo público",2,"Bruce Wayne");

        [TestMethod]
        public void Given_a_product_has_not_been_drawee_should_return_false()
        {
            Assert.AreEqual(_validTodo.Drawee, false);
        }
    }
