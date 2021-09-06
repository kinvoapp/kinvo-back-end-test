using Domain.Interfaces.InterfaceSevices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.InterfaceConsulta;

namespace Domain.Services
{
    public class ServiceConsulta : IServiceConsulta
    {
        private readonly IConsulta _IConsulta;

        public ServiceConsulta(IConsulta IConsulta)
        {
            _IConsulta = IConsulta;
        }

        public async Task AddConsulta(Consulta consulta)
        {
            //REGRAS DE NEGOCIO
            var validaRenda = consulta.ValidarRendaAplicada(consulta.Renda, "Renda");
            var validaLucro = consulta.ValidarLucro(consulta.Lucro, "Lucro");
            var validaDAplicacao = consulta.ValidarDataAplicacao(consulta.DataAplicacao, "DataAplicacao");
            var validaDResgate = consulta.ValidarDataResgate(consulta.DataResgate, "DataResgate");
            var validaDResgateSobreAplicacao = consulta.ValidarDataResgateSobreAplicacao(consulta.DataResgate, consulta.DataAplicacao, "DataResgate");

            if (validaRenda && validaLucro && validaRenda && validaDAplicacao && validaDResgate && validaDResgateSobreAplicacao)
            {
               //SE PASSAR PELAS REGRAS DE NEGOCIO APLICAR OS CALCULOS E PREENCHER O IOF, IR, VALOR DO IR E O VALOR DO RESGATE
               var iof = AddIOF(consulta.DataAplicacao, consulta.DataResgate);
               var ir = AddIR(consulta.DataAplicacao, consulta.DataResgate);
               var valorIR = AddValorIR(consulta.Lucro, iof, ir);
               var resgate = AddRendaComIR(consulta.Renda, consulta.Lucro, valorIR);
               consulta.IOF = iof;
               consulta.IR = ir;
               consulta.ValorIR = valorIR;
               consulta.Resgate = resgate;
               await _IConsulta.Add(consulta);
            }
        }

        //ADICIONAR O IOF DE ACORDO COM O TEMPO
        public double AddIOF(DateTime aplicacao, DateTime resgate)
        {

            DateTime start = aplicacao;
            DateTime end = resgate;
            var diferenca = (end - start).Days;
            if (diferenca <= 30)
            {
                double iof = 99;
                for (int i = 0; i < diferenca; i++)
                {
                    if(iof % 10 == 0)
                    {
                        iof = iof - 4;
                    }
                    else
                    {
                        iof = iof - 3;
                    }
                }
                return iof;
            }
            else
            {
                return 0;
            }
        }

        //ADICIONAR IR DE ACORDO COM A DIFEREÇA DA DATA DE APLICAÇÃO E RESGATE
        public double AddIR(DateTime aplicacao, DateTime resgate)
        {
            double IR;
            DateTime start = aplicacao;
            DateTime end = resgate;
            var diferenca = (end - start).Days;
            if (diferenca <= 360)
            {
                IR = 22.5;
            }
            else
            if (diferenca > 361 && diferenca <= 720)
            {
                IR = 18.5;
            }
            else
            {
                IR = 15;
            }
            return IR;
        }
        
        //ADICIONAR O VALOR DA IR DE ACORDO COM OS VALORES DO LUCRO, IOF E IR
        public double AddValorIR(double lucro, double iof, double ir)
        {
            if(iof == 0)
            {
                var ValorIR = lucro * (ir / 100);
                ValorIR = Math.Round(ValorIR, 2);
                return ValorIR;
            }
            else
            {
                var ValorIOF = lucro * (iof / 100);
                var ValorIR = ValorIOF + (ValorIOF * (ir / 100));
                ValorIR = Math.Round(ValorIR, 2);
                return ValorIR;
            }
        }

        //CALCULAR O VALOR DO RESGATE DE ACORDO COM A RENDA, LUCRO E VALOR DA IR
        public double AddRendaComIR(double Renda, double lucro, double ValorIR)
        {
            var resgate = Renda + (lucro - ValorIR);
            return resgate;
        }
    }
}

