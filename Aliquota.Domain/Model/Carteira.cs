using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.Domain.Model
{
    [Table("Carteira")]
    public class Carteira
    {
        public Guid Id { get; set; }
        public DateTime DataCriacaoCarteira { get; set; }
        public string NomeCliente { get; set; } // Model Cliente simplificado
        public decimal Valor { get; set; }
        
        public virtual ICollection<Investimento> investimentos { get; set; }

        public Carteira()
        {

        }

        public Carteira(string nome)
        {
            Id = Guid.NewGuid();
            DataCriacaoCarteira = DateTime.Now;
            Valor = 0;
            NomeCliente = nome;
            ValidarModel();
        }

        public bool ValidarModel()
        {
            if(NomeCliente == String.Empty)
            {
                throw new ArgumentNullException("Nome do cliente vazio");
            }
            return true;
        }


        private void AtualizarRendimento()
        {
            foreach(var investimento in investimentos)
            {
                Valor += investimento.Total;
            }
        }

    }
}