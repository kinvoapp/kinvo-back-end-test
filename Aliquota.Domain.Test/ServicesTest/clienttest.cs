using Aliquota.Domain.Infra.Context;
using Aliquota.Domain.Entities;
using Aliquota.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Aliquota.Domain.Test.ServicesTest
{
    public class clienttest
    {
        [Fact]
        public void CreateClient()
        {
            var option = new DbContextOptionsBuilder<appcontext>()
                .UseInMemoryDatabase(databaseName: "CreateClient")
                .Options;

            using (var context = new appcontext(option))
            {
                var client = new client();
                client.name = "Flávio";
                client.cpf = "04745578840";

                var clientservice = new clientservice(context);
                clientservice.CreateClient(client);
            }

            using (var context = new appcontext(option))
            {
                Assert.Equal(1, context.clients.Count());
                Assert.Equal("Flávio", context.clients.Single().name);
                Assert.Equal("04745578840", context.clients.Single().cpf);
                Assert.Equal(1, context.clients.Single().id);
            }
        }

        [Fact]
        public void SearchClient()
        {
            var option = new DbContextOptionsBuilder<appcontext>()
                .UseInMemoryDatabase(databaseName: "SearchClient")
                .Options;

            using (var context = new appcontext(option))
            {
                var client = new client();
                client.name = "Flávio";
                client.cpf = "04745578840";

                var clientservice = new clientservice(context);
                clientservice.CreateClient(client);
            }

            using (var context = new appcontext(option))
            {
                var client = new client();
                client.cpf = "04745578840";

                var service = new clientservice(context);
                client clients = service.SearchClient(client);

                Assert.Equal("Flávio", clients.name);
                Assert.Equal("04745578840", clients.cpf);
                Assert.Equal(1, clients.id);
            }
        }
    }
}
