using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Aliquota.Domain
{
    public class Aplicacao
    {
        public int codigoAplicacao;
        public String nomeCliente;
        public Decimal valorAplicacao;
        public String dataInicial;
        public int GetCodigo() => this.codigoAplicacao; 
        public String GetNomeCliente() => this.nomeCliente;
        public Decimal GetValor() => this.valorAplicacao; 
        public String GetDataInicial() => this.dataInicial; 
        public void SetCodigo(int codigo) { this.codigoAplicacao = codigo; }
        public void SetNomeCliente(String nome) { this.nomeCliente = nome; }
        public Boolean SetValor(Decimal valor) {
			if (valor <= 0)
			{
			    return false;
			}
			else { 
				this.valorAplicacao = valor; 
				return true;
			}
			 
		}
        public void SetDataInicial(String data) { this.dataInicial = data; }
		static readonly NumberFormatInfo nfi = new CultureInfo("pt-BR", false).NumberFormat;
		static readonly CultureInfo culture = new CultureInfo("pt-BR", false);

		public Aplicacao Criar(int codigo,String nome, Decimal valor, String dataInicial)

       {
           try
            {
                this.SetCodigo(codigo);
                this.SetNomeCliente(nome);
                this.SetValor(valor);
                this.SetDataInicial(dataInicial);
            } catch(Exception e) { 
                Console.WriteLine(e.ToString()); 
               
            }

                      
            return this;
        }




		public Boolean Resgatar(string data, Aplicacao Ap)
		{
			Boolean resultado = true;
			Double aliquota1 = 0.225;
			Double aliquota2 = 0.185;
			Double aliquota3 = 0.15;
			if (Ap != null) {
				try
				{
					DateTime dataFinal = DateTime.Parse(data.ToString(culture));
					Decimal valor = Ap.GetValor();
					DateTime dataInicial = DateTime.Parse(Ap.GetDataInicial().ToString(culture));
					TimeSpan ts = dataFinal - dataInicial;
					if ((int)ts.Days < 0)
					{
						Console.WriteLine("A data de resgate não pode ser menor que a data de adesão!");
						resultado = false;
					}

					Double anos = (int)ts.Days / 365.2425;

					Double valor1ano = (Double)valor * aliquota1;
					Double valor2ano = (Double)valor * aliquota2;
					Double valor3ano = (Double)valor * aliquota3;

					if (anos < 1 && anos >= 0)
					{
						Console.WriteLine("Aplicação menor que 1 ano, aliquota do IR: 22,5%");
						Console.WriteLine($"Valor total recolhido pelo IR: {valor1ano.ToString("C", nfi)}");

					}

					if (anos >= 1 && anos < 2)
					{
						Console.WriteLine("Aplicação maior que 1 ano e menor que 2 anos, aliquota do IR: 18,5%");
						Console.WriteLine($"Valor total recolhido pelo IR: {valor2ano.ToString("C", nfi)}");
					}
					if (anos >= 2)
					{
						Console.WriteLine("Aplicação maior que 2 anos, aliquota do IR: 15%");
						Console.WriteLine($"Valor total recolhido pelo IR: {valor3ano.ToString("C", nfi)}");
					}


				}
				catch (Exception e) { e.ToString(); resultado = false; }
			}

			else
			{
				resultado = false;
			}


			return resultado;

		}





	}





}
