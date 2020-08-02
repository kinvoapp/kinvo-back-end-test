using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.Domain.Model
{
    [Table("Carteira")]
    public class Carteira
    {
        [Key]
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

        public Object SacarValor(decimal valorSacar)
        {
            if(valorSacar <= 0)
            {
                throw new ArgumentException("Parâmetro para sacar inválido!");
            }else if((Valor - valorSacar) < 0)
            {
                throw new ArgumentException("Valor sacado maior que o disponível!");
            }
            else
            {
                AtualizarRendimento();
                Valor -= valorSacar;

                return new {
                    IR = 0,
                    Valor
                };
            }

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