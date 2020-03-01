using System;

namespace Aliquota.Domain
{
    public class ProdutoFinanceiro
    {
        private double _lucro;
        public double _aplicacao { get; set; }
        public DateTime _dataAplicacao { get; set; }

        public ProdutoFinanceiro() { }
        public ProdutoFinanceiro(double aplicacao, DateTime dataAplicacao)
        {
            if (aplicacao <= 0)
            {
                throw new NotImplementedException("Valor aplicado é Inválido");
            }
            _aplicacao = aplicacao;
            _dataAplicacao = dataAplicacao;
        }
        //No problema não foi informado como o lucro seria calculado, então fiz um metódo para incremento
        public void LucroAdd(double lucro) => _lucro += lucro;
        public bool Aplicar(double aplicacao, DateTime dataAplicacao)
        {
            if (aplicacao > 0)
            {
                _aplicacao = aplicacao;
                _dataAplicacao = dataAplicacao;
                return true;
            }
            throw new NotImplementedException("Not fully implemented.");
        }
        public double Resgate(DateTime dataResgate)
        {
            //Teste de para verificar se a data de não é negativa a data de aplicacao
            if (dataResgate < _dataAplicacao)
            {
                throw new NotImplementedException("Data de resgate é menor que a data de aplicacao");
            }
            return _lucro - CalculoIR(_lucro, dataResgate); //Valor calculado com o IR recolhido
        }
        public double CalculoIR(double lucro, DateTime dataResgate)
        {
            int diascorridos = (int)dataResgate.Subtract(_dataAplicacao).TotalDays;
            if (diascorridos >= 0 && diascorridos < 365)//até um ano
            {
                return lucro * 0.225;
            }
            else if (diascorridos >= 365 && diascorridos <= 730)//1 ano até 2 anos
            {
                return lucro * 0.185;
            }
            else if (diascorridos > 730)//maior que 2 anos
            {
                return lucro * 0.15;
            }
            throw new NotImplementedException("Data de resgate é menor que a data de aplicacao");
        }
    }
}
