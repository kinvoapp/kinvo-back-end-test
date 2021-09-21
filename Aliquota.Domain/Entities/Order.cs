using System;
using System.Collections.Generic;

namespace Aliquota.Domain.Entities
{
    public class Order : Entity
    {
        private IList<Product> _products;
        public Order(Client client)
        {
            Client = client;
            _products = new List<Product>();
        }

        public Client Client { get; private set; }
        public double TaxValue { get; private set; }

        public void SaveOrder(Product product)
        {
            //Product = product;
        }
        public IEnumerable<Product> AddProducts(Product product)
        {
            _products.Add(product);
            AddNotification("AddProducts", "Produto adicionado com sucesso !");
            return _products;
        }
        public double ReturnProductTax(Product product)
        {
            AddNotification("ReturnProdictTax", "Cliente resgatou o valor !");
            TaxValue = product.CalculationOfIncomeTaxCollection();
            return TaxValue;
        }
    }
}

