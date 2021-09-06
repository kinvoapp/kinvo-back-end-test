using KinvoTeste.Models;
using KinvoTesteConsole.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KinvoTesteConsole.Service
{
    public class ContaService
    {
        public bool Depositar(string valorString, Usuario usuario)
        {
            double valor; 
            if(!double.TryParse(valorString.Replace(".",","), out valor))
            {
                Console.WriteLine("Valor inválido!");
                return false;
            }

            var client = new HttpClientHelper();
            try
            {
                var param = new Dictionary<string, object>();
                param.Add("valor", valor.ToString().Replace(",", "."));
                var retorno = client.Path($"Conta/{usuario.Contas.First().Id}", param).Result;
                if (!string.IsNullOrWhiteSpace(retorno))
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}
