using System;

namespace Aliquota.Domain.Models
{
    public class Aplicacao : Entity
    {
        public Aplicacao() : base()
        {
            Ativo = true;
        }

        public string Nome { get; set; }
        public decimal ValorAplicado { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime DataAplicacao { get; set; }
        public DateTime? DataRetirada { get; set; }
        public bool Ativo { get; set; }

        public Guid? UserId { get; set; }

        public virtual decimal AliquotaIR { 
                get {
                decimal DiferencaAnos = 0;

                if (DataRetirada.HasValue)
                {
                    DiferencaAnos = Convert.ToDecimal((DataRetirada.Value.Subtract(DataAplicacao).TotalDays) / 360);
                }

                if (DiferencaAnos < 1)
                {
                    return Convert.ToDecimal(0.225);
                }
                else if (DiferencaAnos >= 1 && DiferencaAnos <= 2)
                {
                    return Convert.ToDecimal(0.185);
                }
                else
                {
                    return Convert.ToDecimal(0.15);
                }
            }
        }

        public virtual decimal ValorIR { get { 
                return  (ValorAtual - ValorAplicado) * AliquotaIR;
            }
        }
        public virtual decimal ValorResgate { get {
                return ValorAtual - ValorIR;
            } 
        }


    }
}
