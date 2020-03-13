using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class Aplicacao
    {
        [Key] 
        public int AplicacaoId { get; set; }
        public double valorAplicacao { get; set; }
        
        public DateTime dataResgate { get; set; }
        public DateTime dataAplicacao { get; set; }

        public override string ToString()
        {
            return $"ID: {AplicacaoId}\nValor: {valorAplicacao}\nData Resgate: {dataResgate}\n Data Aplicacao: {dataAplicacao}";
        }
    }
}