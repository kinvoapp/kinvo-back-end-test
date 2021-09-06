using Aliquota.Domain.Service;
using System;

namespace KinvoTeste.Models
{
    public class Produto
    {

        //Valor em porcentagem para calculo e rentabilidade ao mês
        private const double RentabilidadeAM = 0.10;

        public int Id { get; set; }
        public double ValorInvestido { get; set; }
        public DateTime DataAplicacao { get; set; }

        public double ValorBruto => ObterValorBruto(DateTime.Now);

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Resgate Resgate { get; set; }

        public Produto()
        {
            DataAplicacao = DateTime.Now;
        }

        private double ObterValorBruto(DateTime dataFinal)
        {
            int mesesDiff = ajustaMesAno(dataFinal) - ajustaMesAno(DataAplicacao);

            var m = ValorInvestido * Math.Pow((1 + RentabilidadeAM),(double)mesesDiff);
            if (m <= 0)
                m = ValorInvestido;

            return m;
        }

        private int ajustaMesAno(DateTime d)
        {
            return d.Year * 12 + d.Month;
        }

        public void CalcularResgate(DateTime dataResgate)
        {
            if(dataResgate.Date >= DataAplicacao)
            {
                var aliqservice = new AliquotaService();
                var aliq = aliqservice.Calcular(DataAplicacao, dataResgate);
                Resgate = new Resgate() { ValorInvestido = ValorInvestido, ValorBruto = ValorBruto, AlicotaIR = aliq };
            }
        }
    }
}
