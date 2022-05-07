using System;

namespace Aliquota.Application.DTO
{
    public enum Tipo {
        Aquisicao,
        Resgate
    }

    public class MovimentacaoDTO
    {
        public int Id { get; set; }
        public double Valor { get; set; }

        public DateTime DataMovimentacao { get; set; }

        public Tipo Tipo { get; set; }

        public Guid Identificador { get; set; }

        public MovimentacaoDTO()
        {
            Identificador = Guid.NewGuid();
        }



    }
}