using Aliquota.Domain.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities.Entidades
{
    public class SituacaoProduto : IEntidade<int>
    {
        public int Id { get; set; }
        public string Descricao { get { return @"Entidade responsavel por guardar a situação atual do produto. Exemplo 'Não movimentado', 'Movimentado','Bloqueado' e etc..."; } }
        public string Situacao { get; set; }

        public ICollection<Produto> ProdutoLista { get; set; }
    }
}
