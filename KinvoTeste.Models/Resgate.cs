namespace KinvoTeste.Models
{
    public class Resgate
    {
        public double ValorInvestido { get; set; }
        public double ValorBruto { get; set; }
        public double AlicotaIR { get; set; }

        public double LucroBruto => ValorBruto - ValorInvestido;
        public double ValorIR => LucroBruto * AlicotaIR;
        public double LucroLiquido => LucroBruto - ValorIR;
        public double ValorLiquido => ValorInvestido + LucroLiquido;

    }
}
