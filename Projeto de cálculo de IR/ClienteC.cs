
using Database;
using System.Data.Entity;

namespace Projeto_de_cálculo_de_IR
{
    public class ClienteC : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
       
    }
}
