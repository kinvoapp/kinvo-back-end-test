using System;

namespace Aliquota.Domain
{
    public class Calculadora
    {
        Produto produto = new Produto();

       //Recebe e testa se o valor aplicado é válido
        public double ValorAplicado(double valor)
        {
            if (valor > 0)
            {
                produto.ValorAplicado = valor;
                return produto.ValorAplicado;
            }
            else
            {
                throw new Exception("Valor Inválido");
            }
            
            
        }

        //Calcula a duração da aplicação e testa
        public double DuracaoAplicado(string dataAplicada, string dataRetirada)
        {
            produto.TempoDeAplicacao = (DateTime.Parse(dataRetirada).Subtract(DateTime.Parse(dataAplicada)).TotalDays / 365.2425);

            if (produto.TempoDeAplicacao > 0)
            {
                return produto.TempoDeAplicacao;
            }
            else
            {
                throw new Exception("Datas Incorretas");
            }
        }

        //Calcula o lucro da aplicação
        public double CalculaLucro(double lucro)
        {
            produto.Lucro = produto.ValorAplicado * (lucro / 100);
            return produto.Lucro;
        }

        //Calcula o valor do imposto de renda
        public double AliquotaCalculada()
        {
           
            if (produto.TempoDeAplicacao <= 0)
            {
                throw new Exception("Datas Incorretas");
                
            }
            if (produto.TempoDeAplicacao <= 1 && produto.TempoDeAplicacao > 0)
            {
                produto.Imposto = produto.Lucro * 0.225;
                
            }
            if (produto.TempoDeAplicacao > 1 && produto.TempoDeAplicacao <= 2)
            {
                produto.Imposto = produto.Lucro * 0.185;
               
            }
            if (produto.TempoDeAplicacao > 2)
            {
                produto.Imposto = produto.Lucro * 0.15;
                
            }
            return produto.Imposto;
        }
    }
}
