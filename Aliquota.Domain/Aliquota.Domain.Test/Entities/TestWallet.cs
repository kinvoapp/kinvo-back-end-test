using Aliquota.Domain.Entities;
using Aliquota.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aliquota.Domain.Test.Entities
{
    public class TestWallet
    {
        [Fact]
        public void TestInitWhenValidArgsThenBuildWallet()
        {
            //Arrange
            Guid clientID = Guid.NewGuid();
            string amountMoneyValue = "10000.00";
            AmountMoney _amountMoney = new AmountMoney(double.Parse(amountMoneyValue));

            //Action
            Wallet wallet = new Wallet(clientID, _amountMoney);

            //Assert
            Assert.IsType<Wallet>(wallet);
        }
    }
}
