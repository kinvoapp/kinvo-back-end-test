using System.Collections.Generic;
using System.Linq;
using FinancialProduct.Domain.Entities;
using FinancialProduct.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialProduct.Test.QueryTests;

[TestClass]
public class TodoQueryTests
{
    private List<Product> _items;

    public TodoQueryTests()
    {
        _items = new List<Product>();
        _items.Add(new Product("titulo 1", 10, "usuario A"));
        _items.Add(new Product("titulo 2", 10, "usuario B"));
        _items.Add(new Product("titulo 3", 10, "bruce wayne"));
        _items.Add(new Product("titulo 4", 10, "usuario C"));
        _items.Add(new Product("titulo 5", 10, "bruce wayne"));
    }

    [TestMethod]
    public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_brucewayne()
    {
        var result = _items.AsQueryable().Where(ProductQuery.GetAllQuery("bruce wayne"));
        Assert.AreEqual(2, result.Count());
    }
}
