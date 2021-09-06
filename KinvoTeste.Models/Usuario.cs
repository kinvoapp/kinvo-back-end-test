using System.Collections.Generic;

namespace KinvoTeste.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
        public List<Conta> Contas { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
