using KinvoTeste.Models;
using System.Linq;

namespace KinvoTeste.Data
{
    public class ContaRepository
    {
        public int Atualizar(Conta conta)
        {
            using (var dbContext = new Context())
            {
                dbContext.Contas.Update(conta);
                dbContext.SaveChanges();
                return conta.Id;
            }
        }

        public Conta Obter(int id)
        {
            using (var dbContext = new Context())
            {
                return dbContext.Contas.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
