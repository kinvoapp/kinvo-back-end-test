using KinvoTeste.Models;
using System.Linq;

namespace KinvoTeste.Data
{
    public class ProdutoRepository
    {
        public int Add(Produto produto)
        {
            using (var dbContext = new Context())
            {
                dbContext.Produtos.Add(produto);
                dbContext.SaveChanges();
                return produto.Id;
            }
        }

        public void Delete(int id)
        {
            using (var dbContext = new Context())
            {
                var prod = dbContext.Produtos.FirstOrDefault(x => x.Id == id);
                dbContext.Produtos.Remove(prod);
                dbContext.SaveChanges();
            }
        }
    }
}
