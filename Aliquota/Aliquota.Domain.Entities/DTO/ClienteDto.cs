using Aliquota.Domain.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliquota.Domain.Entities.DTO
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public int IdCliente { get { return Id; } }
        public string NomeCliente { get; set; }
        public List<ProdutoDto> ProdutoLista { get; set; }

        public ClienteDto()
        {
            ProdutoLista = new List<ProdutoDto>();
        }

        public ClienteDto(Cliente cliente)
        {
            Id = cliente.Id;
            NomeCliente = cliente.NomeCliente;
            ProdutoLista = cliente.ProdutoLista != null && cliente.ProdutoLista.Any()? cliente.ProdutoLista.Select(a=> new ProdutoDto(a)).ToList(): new List<ProdutoDto>();
        }
    }
}
