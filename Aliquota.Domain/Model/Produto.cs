﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aliquota.Domain.Model
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public uint Id { get; }
        public string Nome { get; set; }
        public decimal TaxaAnual { get; set; }
        public DateTime Vencimento { get; set; }


        public Produto(uint id,string nome,decimal taxa_anual,DateTime vencimento)
        {
            Id = id; // Change Auto generated by DB
            Nome = nome;
            TaxaAnual = taxa_anual;
            Vencimento = vencimento;
            ValidarModel();

        }

        public Produto()
        {

        }

        public bool ValidarModel()
        {
            if(Id <= 0)
            {
                throw new ArgumentException("Id do produto inválido!");
            }else if(Nome == String.Empty)
            {
                throw new ArgumentException("Nome do Produto não pode ser vazio!");
            }
            else if (TaxaAnual <= 0)
            {
                throw new ArgumentException("Taxa Anual do Produto não inválido!");
            }
            else if (Vencimento < DateTime.Now)
            {
                throw new ArgumentException("Vencimento do Produto não ser menor que horário atual!");
            }
            else
            {
                return true;
            }

        }
    }
}
