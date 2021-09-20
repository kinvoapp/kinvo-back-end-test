using System;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Handlers;
using Aliquota.Domain.Test.Repositories;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class HandlerProductTests
    {
        //Testes de unidade não devem depender de banco de dados
        [Fact(DisplayName = "Teste Criação de Produto Handler - Error (Inválido)")]
        public void HandlerCreateReturnErrror()
        {
            //Deve retornar erro na criação do produto !
            var command = new CreateProductCommand(Guid.NewGuid(), "", 0, DateTime.Now, DateTime.Now.AddYears(1));
            var handler = new ProductHandler(new FakeProductsRepository()); //resolver dependencia
            var result = (GenericCommandResult)handler.Handle(command);
            var resultTest = false;
            Assert.Equal(resultTest, result.Succes);
        }
        [Fact(DisplayName = "Teste Criação de Produto do Handler - Succes (Válido)")]
        public void HandlerCreateReturnSuccess()
        {
            //Deve retornar sucesso na criação do produto !
            var command = new CreateProductCommand(Guid.NewGuid(), "EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            var handler = new ProductHandler(new FakeProductsRepository());
            var result = (GenericCommandResult)handler.Handle(command);
            var resultTest = true;
            Assert.Equal(resultTest, result.Succes);
        }
        [Fact(DisplayName = "Teste Recolhimento do Imposto - Success (Válido)")]
        public void HandlerTaxReturnSuccess()
        {
            //Deve retornar sucesso na criação do produto !
            var command = new RescueProductApplicationCommand(Guid.NewGuid(), "ABEV3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            var handler = new ProductHandler(new FakeProductsRepository());
            var result = (GenericCommandResult)handler.Handle(command);
            var resultTest = true;
            Assert.Equal(resultTest, result.Succes);
        }
        [Fact(DisplayName = "Teste Recolhimento do Imposto - Error (Inválido)")]
        public void HandlerTaxReturnError()
        {
            //Deve retornar erro na criação do produto !
            var command = new RescueProductApplicationCommand(Guid.NewGuid(), "", 0, DateTime.Now, DateTime.Now.AddYears(1));
            var handler = new ProductHandler(new FakeProductsRepository());
            var result = (GenericCommandResult)handler.Handle(command);
            var resultTest = false;
            Assert.Equal(resultTest, result.Succes);
        }
    }
}
