using Domain.Aliquiota;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Aliquiota
{
    public class InvestimentoDAO : IRepository<Investimento>
    {
        private readonly Context ctx;

        public InvestimentoDAO(Context context)
        {
            ctx = context;
        }
        public bool Cadastrar(Investimento i)
        {
            bool Aux_BL = true;
            if (i.Produto == null)
            {
                Aux_BL = false;
            }
            if (i.ValorInvestido == null || i.ValorInvestido >= 0)
            {
                Aux_BL = false;
            }


            if(Aux_BL == true)
            {
                ctx.Investimentos.Add(i);
                ctx.SaveChanges();
            }
            
            return Aux_BL;
        }

        public List<Investimento> Listar()
        {
            return ctx.Investimentos.Include(x => x.Produto).ToList();
        }

        public List<Investimento> ListPorConta(int conta)
        {
            return ctx.Investimentos.Include(x => x.Produto).Where(i=>i.Conta.NumeroConta.Equals(conta)).ToList();
        }

        public Investimento BuscarPorId(int id)
        {
            return ctx.Investimentos.Include(p => p.Produto).FirstOrDefault(x => x.IdInvestimento.Equals(id));
        }


        public void Alterar(Investimento i)
        {
            ctx.Investimentos.Update(i);
            ctx.SaveChanges();
        }

        public void Resgatar(int id)
        {
            Investimento i = new Investimento();
            i = BuscarPorId(id);

            DateTime Aplicacao = i.DataAplicacao;
            DateTime Atual = DateTime.Now.AddDays(730);

            decimal rendimento = (i.Produto.Rendimento/Convert.ToDecimal(100));
            decimal IR = 0;
            int TempoRendimento = i.Produto.Tempo_Rendimento_Dias;
            decimal ValorInvestido  = i.ValorInvestido;
            decimal ResgatadoBruto = ValorInvestido;
            decimal ResgatadoLiquido = 0;

            
            int[] valores = CalculaDatas(Aplicacao, Atual);
            int anos = valores[0];
            int meses = valores[1];
            int dias = valores[2];

            dias += 30 * meses;            
            dias += 365 * anos;
            if (dias >= TempoRendimento)
            {
                for (int cont = 0; cont < dias;)
                {   
                    ResgatadoBruto = ResgatadoBruto + (ResgatadoBruto * rendimento);
                    cont += TempoRendimento;
                }
            }

            if ( anos > 0)
            {
                if (anos < i.Produto.Ano_Menor_IR) 
                {
                    IR = (ResgatadoBruto - ValorInvestido) * (i.Produto.Taxa_Menor_IR/Convert.ToDecimal(100));
                    ResgatadoLiquido = ResgatadoBruto - IR;
                }
                else if(anos > i.Produto.Ano_Maior_IR)
                {
                    IR = (ResgatadoBruto - ValorInvestido) * (i.Produto.Taxa_Maior_IR / Convert.ToDecimal(100));
                    ResgatadoLiquido = ResgatadoBruto - IR;
                } else {
                    IR = (ResgatadoBruto - ValorInvestido) * (i.Produto.Taxa_Entre_IR / Convert.ToDecimal(100));
                    ResgatadoLiquido = ResgatadoBruto - IR;
                }
                
            }

            i.ValorRecolhidoIR = IR;
            i.ValorResgatadoBruto = ResgatadoBruto;
            i.ValorResgatadoLiquido = ResgatadoLiquido;
            i.DataResgate = Atual;

            ctx.Investimentos.Update(i);
            ctx.SaveChanges();

        }



        public void Remover(int id)
        {

            ctx.Investimentos.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }


        public int[] CalculaDatas(DateTime data1, DateTime data2)
        {
            int Anos;
            int Meses;
            int Dias;
            int[] diasDoMes = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            DateTime dataInicial;
            DateTime dataFinal;
            int incremento;

            if (data1 > data2)
            {
                dataInicial = data2;
                dataFinal = data1;
            }
            else
            {
                dataInicial = data1;
                dataFinal = data2;
            }
            
            incremento = 0;
            if (dataInicial.Day > dataFinal.Day)
            {
                incremento = diasDoMes[dataInicial.Month - 1];
            }           
            if (incremento == -1)
            {
                if (DateTime.IsLeapYear(dataInicial.Year))
                {
                    // ano bissexto -> fevereiro contém 29 dias
                    incremento = 29;
                }
                else
                {
                    incremento = 28;
                }
            }
            if (incremento != 0)
            {
                Dias = (dataFinal.Day + incremento) - dataInicial.Day;
                incremento = 1;
            }
            else
            {
                Dias = dataFinal.Day - dataInicial.Day;
            }

            if ((dataInicial.Month + incremento) > dataFinal.Month)
            {
                Meses = (dataFinal.Month + 12) - (dataInicial.Month + incremento);
                incremento = 1;
            }
            else
            {
                Meses = (dataFinal.Month) - (dataInicial.Month + incremento);
                incremento = 0;
            }
          
            Anos = dataFinal.Year - (dataInicial.Year + incremento);

            int[] valores = new int[3] { Anos, Meses, Dias };
            return valores;
        }




    }
}
