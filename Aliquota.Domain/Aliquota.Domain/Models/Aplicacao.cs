using System;
using System.ComponentModel.DataAnnotations;
using static Aliquota.Domain.Utils;

#nullable disable

namespace Aliquota.Domain.Models
{
    public partial class Aplicacao
    {
        public int AplicacaoId { get; set; }
        [DateTimeSmallerThanNow(ErrorMessage = "A data não pode ser maior que a data atual.")]
        public DateTime Data { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "A aplicação não pode ser igual ou menor que zero.")]
        public double Valor { get; set; }
        public double TaxaLucro { get; set; }
        public Periodicidades Periodicidade { get; set; }

        public bool Resgatado { get; set; }
        public int? ClienteId { get; set; }

        public double Rendimento
        {
            get
            {
                DiferencaDatas dif = Utils.CalculaDiferencaDatas(DateTime.Now, this.Data);
                int quantidade = this.Periodicidade == Periodicidades.Anual ? dif.anos : dif.meses;
                double rendimento = (Valor * Math.Pow(1 + (TaxaLucro / 100), Convert.ToDouble(quantidade))) - Valor;
                return Math.Round(rendimento, 2);
            }
        }

        public virtual Cliente Cliente { get; set; }
        public virtual Resgate Resgate { get; set; }

        public enum Periodicidades
        {
            Mensal = 'M',
            Anual = 'A'
        }
        public double calculaIR(DateTime dataResgate)
        {
            DiferencaDatas diferencaDatas = Utils.CalculaDiferencaDatas(dataResgate, this.Data);
            switch (diferencaDatas.anos)
            {
                //Até 1 ano de aplicação: 22,5 % sobre o lucro
                case 0:
                    return Rendimento * 0.225;
                //De 1 a 2 anos de aplicação: 18,5 % sobre o lucro
                case 1:
                    return Rendimento * 0.185;
                //Acima de 2 anos de aplicação: 15 % sobre o lucro
                default:
                    return Rendimento * 0.15;
            }
        }
    }
}
