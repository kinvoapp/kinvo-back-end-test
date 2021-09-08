using System;

namespace Aliquota.Domain
{
    public class Investimento
    {
        public int investimentoId{get;set;}
        public float aplicação {get;set;}
        public float lucroTotal {get;set;}
        public float redimentoPorMes {get;set;}
        public string dataEntrada {get;set;}
        public string dataRetirada {get;set;}
        public float impostoDeRenda {get;set;}
        public float jurosImpostoDeRenda {get;set;}
    }
}