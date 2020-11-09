using System;

namespace Aliquota.Domain.Models
{
    public class ProdutoFinanceiro{
        private ProdutoFinanceiro(){}

        public ProdutoFinanceiro(Guid id, Cliente cliente,decimal Valor, DateTime DataAplicacao, DateTime DataResgate){
            Validador.MaiorQueZero(Valor, "valor");
            Validador.MaiorQueData(DataResgate,DataAplicacao);
            this.Id = id; 
            this.Cliente = cliente; 
            this.Valor = Valor;
            this.DataAplicacao = DataAplicacao;
            this.DataResgate = DataResgate;
            this.AliquotaImposto = this.CalcularAliquotaImposto();
        }

        public Guid Id { get; }
        public decimal Valor { get;}
        public DateTime DataAplicacao { get;}
        public DateTime DataResgate { get; }
        public decimal AliquotaImposto { get; }

        public Cliente Cliente { get; set; }

        private decimal CalcularAliquotaImposto(){
            TimeSpan diferenca = (this.DataResgate - this.DataAplicacao);
            int dias = diferenca.Days;
            if(dias <= 365){
                return new Decimal(22.5);
            }
            else if(dias <= 730){
                return new Decimal(18.5);
            }
            else{
                return new Decimal(15.0);
            }
        }
    }
}