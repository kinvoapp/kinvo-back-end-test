using System;

namespace Aliquota.Domain.Models
{
    public class CalcIr
    {
        private double _valorIR { get; set; }

        public double ValorIR
        {
            get => _valorIR;
            set => _valorIR = value;
        }

        public double CalcIR(double valorAplicacao, DateTime dataResgate, DateTime dataAplicacao)
        {     
            if (valorAplicacao > 0)
            {
                if (dataResgate >= dataAplicacao)
                {
                    long convert = long.Parse(dataResgate.ToString("yyyyMMdd"));
                    long convert2 = long.Parse(dataAplicacao.ToString("yyyyMMdd"));
                
                    if (((convert - convert2) * 0.0001) <= 1)
                    {
                        _valorIR = valorAplicacao * 0.225;
                    }
                    else if (((convert - convert2) * 0.0001) > 1 && ((convert - convert2) * 0.0001) <= 2)
                    {
                        _valorIR = valorAplicacao * 0.185;
                    }
                    else
                    {
                       _valorIR = valorAplicacao - (valorAplicacao * 0.15);
                    }                    
                }       
            }
            else
            {
                Console.WriteLine("O valor da aplicação não pode ser menor ou igual a 0");
            }
            return _valorIR;
        }
    }
}