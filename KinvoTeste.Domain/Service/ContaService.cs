using KinvoTeste.Data;
using KinvoTeste.Models;

namespace KinvoTeste.Domain.Service
{
    public class ContaService
    {
        private ContaRepository Repository { get; set; }

        public ContaService()
        {
            Repository = new ContaRepository();
        }

        public int? Atualizar(int id, double valor)
        {
            var conta = Repository.Obter(id);
            if(conta != null)
            {
                conta.Saldo += valor;
                return Repository.Atualizar(conta);
            }

            return null;
        }
    }
}
