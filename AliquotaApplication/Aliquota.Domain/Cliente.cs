using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain
{
    public class Cliente
    {
        
        public string Nome { get; set; }
        public decimal ValorAplicado { get; set; }
        public DateTime DataDeAplicacao { get; set; }
        

        public override string ToString()
        {
            return $"\nCliente:\n Nome: {this.Nome}\n Valor Aplicado: {this.ValorAplicado}\n Data de Aplicação: {this.DataDeAplicacao}";
        }
    }
}
