using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;

namespace Aliquota.Domain.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderProduct> _products;
        public Order()
        {

        }
        public Order(Client client)
        {
            Client = client;
            //ClientDocument = client.Document;
            _products = new List<OrderProduct>();

            AddNotifications(new Contract().Requires()
            .HasLen(ClientDocument, 11, "ClientDocument", "CPF inválido !"));
        }
        public Client Client { get; private set; }
        public string OrderNumber { get; private set; }
        public string ProductTaxTitle { get; private set; }
        public string ClientDocument { get; private set; }
        public double TaxValue { get; private set; }
        public IReadOnlyCollection<OrderProduct> Products => _products.ToArray();
        public void AddProducts(Product product)
        {
            var order = new OrderProduct(product);
            _products.Add(order);
        }
        public void PlaceOrder()
        {
            //validar
            OrderNumber = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_products.Count == 0)
                AddNotification("Products", "Esta ordem não possui itens !");
        }
        public double ReturnProductTax(Product product)
        {
            AddNotification("ReturnProdictTax", "Cliente resgatou o valor !");
            TaxValue = product.CalculationOfIncomeTaxCollection();
            return TaxValue;
        }

    }
}

