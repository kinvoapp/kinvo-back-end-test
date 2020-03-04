using System;

namespace Aliquota.Domain
{
  public  class Aplicacao
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public Produto Produto { get; set; }
        public Cliente Cliente { get; set; }
        public Resgate Resgate { get; set; }
        //public decimal Valor { get; set; }

       

         
    }
}
