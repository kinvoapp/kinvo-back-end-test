using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Aliquota.Domain.Models
{
    public partial class Resgate
    {
        public int ResgateId { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public double ValorIr { get; set; }
        [ForeignKey("AplicacaoID")]
        public int? AplicacaoId { get; set; }
        public virtual Aplicacao Aplicacao { get; set; }

        public Resgate()
        {
           
        }
        public Resgate(Aplicacao Aplicacao)
        {
            this.Data = DateTime.Now;
            if (this.Data < Aplicacao.Data)
                throw new Exception("A data de resgate não pode ser menor que a data da aplicação.");
            this.AplicacaoId = Aplicacao.AplicacaoId;
        }
    }
}
