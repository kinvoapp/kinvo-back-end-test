using System;

namespace Aliquota.Domain
{
    public class Controlador
        {
        public void CalcularInvestimento(Usuario u, Investimento i)
        {
        int meses = CalcularMeses(i);
        float lucro = i.aplicação;
        for(int x = 0; x > meses ; x--){
        lucro += (lucro * (i.redimentoPorMes/100));
        }
        i.lucroTotal = Math.Abs(i.aplicação - lucro);
        CalcularJurosImposto(i);
        i.impostoDeRenda = i.lucroTotal*(i.jurosImpostoDeRenda/100);
        u.saldo += (i.lucroTotal - (i.lucroTotal*(i.jurosImpostoDeRenda/100)));

        }

        public void CalcularJurosImposto(Investimento i)
        {
            int meses = CalcularMeses(i);
            if(meses <= 12){
                i.jurosImpostoDeRenda = 22 ;
            }
            else if( meses > 12 && meses < 24){
                i.jurosImpostoDeRenda = 18 ;
            }
            else{
                i.jurosImpostoDeRenda = 15 ;
            }
        }

        public int CalcularMeses(Investimento i)
        {
            DateTime dataEntrada = Convert.ToDateTime(i.dataEntrada);
            DateTime dataRetirada = Convert.ToDateTime(i.dataRetirada);
            TimeSpan date = (dataEntrada - dataRetirada);
            int meses = date.Days/30;


            return meses;
        }

        public int Autenticar(Investimento i)
        {

            DateTime dataEntrada = Convert.ToDateTime(i.dataEntrada);
            DateTime dataRetirada = Convert.ToDateTime(i.dataRetirada);
            int resultado = DateTime.Compare(dataEntrada, dataRetirada);

            if(resultado >= 0 && i.aplicação <= 0)
                return 0;
            else if(resultado >= 0)
                return 0;
            else if(i.aplicação <= 0)
                return 0;
            else
                return 1;
        }


    }
}