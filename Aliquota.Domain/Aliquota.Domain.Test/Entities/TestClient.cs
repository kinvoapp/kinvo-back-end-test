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
    public class TestClient
    {
        [Fact]
        public void TestClientWhenValidArgsThenBuildClient()
        {
            //Arrange
            Guid clientID = Guid.NewGuid();
            string nameValue = "Test";
            string lastNameValue = "kinvo";
            FullName _name = new FullName(nameValue, lastNameValue);
            string emailValue = "test.kinvo@kinvo.com.br";
            Email _email = new Email(emailValue);
            string cpfValue = "01234567891";
            CPF _cpf = new CPF(cpfValue);
            string phoneNumberValue = "19876543210";
            PhoneNumber _phoneNumber = new PhoneNumber(phoneNumberValue);
            
            //Action
            Client client = new Client(clientID, _name, _email, _cpf, _phoneNumber);

            //Assert
            Assert.IsType<Client>(client);

        }
    }
}
