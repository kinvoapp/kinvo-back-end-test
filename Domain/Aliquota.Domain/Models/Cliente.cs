using System;
using System.Collections.Generic;
using System.Linq;

namespace Aliquota.Domain.Models
{
    public class Cliente {
        private Cliente(){}
        public Cliente(Guid id,string Nome, string Cpf, IEnumerable<ProdutoFinanceiro> produtos){
            Validador.NaoNulo(Nome, "nome");
            Validador.NaoNulo(Cpf, "cpf");
            this.Id = id; 
            this.Nome = Nome;
            this.CPF = Cpf;
            this._produtosFinanceiros = new List<ProdutoFinanceiro>();
            _produtosFinanceiros = (produtos ?? Enumerable.Empty<ProdutoFinanceiro>()).ToList();
        }
        
        public Guid Id { get; }
        public string Nome {get; }
        public string CPF {get; }
        private readonly List<ProdutoFinanceiro> _produtosFinanceiros;
        public IReadOnlyCollection<ProdutoFinanceiro> ProdutosFinanceiros => _produtosFinanceiros;    
        
        public void AdicionarProdutoFinanceiro(ProdutoFinanceiro produto)
        {
            if(null == produto){
                throw new ArgumentNullException(nameof(produto));
            }
            this._produtosFinanceiros.Add(produto);
        }

    }
}