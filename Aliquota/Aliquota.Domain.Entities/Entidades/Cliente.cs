using Aliquota.Domain.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities.Entidades
{
    public class Cliente : IEntidade<int>
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Descricao { get => @"Entidade responsável por manter os dados referentes ao cliente"; }
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public ICollection<Produto> ProdutoLista { get; set; }
    }
}
