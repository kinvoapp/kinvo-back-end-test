using System;

namespace Aliquota.Domain.Servicos.ProdutoFinanceiroSv.ValidacaoResgate
{
    public class ValidacaoDataResgate : IValidadorDataResgate
    {
        public DateTime ValidaDataResgate(string dataResgate, DateTime dataAplicacao)
        {
            var dataResgateConvertida = DateTime.Parse(dataResgate);
            if (dataResgateConvertida >= dataAplicacao)
                return dataResgateConvertida;
            else
                throw new ArgumentException();
        }
    }
}
