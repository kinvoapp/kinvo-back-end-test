using Aliquota.Domain.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Entities.DTO
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public List<ProdutoDto> ProdutoLista { get; set; }

        public ClienteDto(Cliente cliente)
        {
            Id = cliente.Id;
            NomeCliente = cliente.NomeCliente;
        }
    }
}
