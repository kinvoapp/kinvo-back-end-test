using System;
using Aliquota.Domain.Commands;
using Aliquota.Domain.Handlers;
using Xunit;

namespace Aliquota.Domain.Test
{
    public class HandlerProductTests
    {
        //Testes de unidade não devem depender de banco de dados
        [Fact(DisplayName = "Teste Criação do Handler - Error (Inválido)")]
        public void HandlerCreateReturnErrror()
        {
            //Deve retornar erro na criação do produto !
            var command = new CreateProductCommand(Guid.NewGuid(), "EGIE3", 250, DateTime.Now, DateTime.Now.AddYears(1));
            //var handler = new ProductHandler(); //resolver dependencia
            var result = false;
            Assert.Equal(result, true);
        }
        [Fact(DisplayName = "Teste Criação do Handler - Succes (Válido)")]
        public void HandlerCreateReturnSuccess()
        {
            //Deve retornar sucesso na criação do produto !

            var result = false;
            Assert.Equal(result, true);
        }
    }
}
