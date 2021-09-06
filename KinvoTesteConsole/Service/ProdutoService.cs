using KinvoTeste.Models;
using KinvoTesteConsole.Helper;
using System;
using System.Collections.Generic;

namespace KinvoTesteConsole.Service
{
    public class ProdutoService
    {
        public bool Investir(string valorString, string dataAplicacao, Usuario usuario)
        {
            double valor; 
            if(!double.TryParse(valorString.Replace(".", ","), out valor))
            {
                Console.WriteLine("Valor inválido!");
                return false;
            }

            var data = DateTime.Now;
            if(dataAplicacao.ToLower() != "hoje")
            {
                if (!DateTime.TryParseExact(dataAplicacao, "dd/MM/yyyy", 
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out data))
                {
                    Console.WriteLine("Data inválida!");
                    return false;
                }

                if(data.Date < DateTime.Now.Date)
                {
                    Console.WriteLine("Data não pode ser menor que hoje!");
                    return false;
                }
            }

            var client = new HttpClientHelper();
            try
            {
                var param = new Dictionary<string, object>();
                param.Add("produto", (new Produto { ValorInvestido = valor, Usuario = usuario }).ToJson());
                var retorno = client.Post("Produto", param).Result;
                if (!string.IsNullOrWhiteSpace(retorno))
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            return false;
        }

        public List<Resgate> Simular(string dataResgate, int idUsuario)
        {
            var data = DateTime.Now;
            if (dataResgate.ToLower() != "hoje")
            {
                if (!DateTime.TryParseExact(dataResgate, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out data))
                {
                    Console.WriteLine("Data inválida!");
                    return null;
                }

                if (data.Date < DateTime.Now.Date)
                {
                    Console.WriteLine("Data não pode ser menor que hoje!");
                    return null;
                }
            }

            var client = new HttpClientHelper();
            try
            {
                var param = new Dictionary<string, object>();
                param.Add("idUsuario", idUsuario);
                param.Add("dataResgate", data.ToString("yyyy-MM-dd"));
                param.Add("simular", "simular");
                var retorno = client.Get("Produto", param).Result;
                if (!string.IsNullOrWhiteSpace(retorno))
                    return retorno.To<List<Resgate>>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            return null;
        }

        public List<Resgate> Regatar(int idUsuario)
        {
            var client = new HttpClientHelper();
            try
            {
                var param = new Dictionary<string, object>();
                param.Add("idUsuario", idUsuario);
                var retorno = client.Get("Produto", param).Result;
                if (!string.IsNullOrWhiteSpace(retorno))
                    return retorno.To<List<Resgate>>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            return null;
        }
    }
}
