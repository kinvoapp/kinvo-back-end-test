using System;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Domain.Entities
{
    public class Order : Entity
    {
        private IList<Product> _products;
        public Order(string user, string document)
        {
            User = user;
            Document = document;
            _products = new List<Product>();
        }
        public string User { get; private set; }
        public string Document { get; private set; }
        public double TaxValue { get; private set; }
        public IReadOnlyCollection<Product> Products => _products.ToArray();
        public void SaveOrder(Product product)
        {
            //Product = product;
        }
        public void AddProducts(Product product)
        {
            _products.Add(product);
            AddNotification("AddProducts", "Produto adicionado com sucesso !");
        }
        public double ReturnProductTax(Product product)
        {
            AddNotification("ReturnProdictTax", "Cliente resgatou o valor !");
            TaxValue = product.CalculationOfIncomeTaxCollection();
            return TaxValue;
        }
    }
}

