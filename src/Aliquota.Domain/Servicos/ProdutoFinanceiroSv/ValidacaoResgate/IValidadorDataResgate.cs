using System;

namespace Aliquota.Domain.Servicos.ProdutoFinanceiroSv.ValidacaoResgate
{
    public interface IValidadorDataResgate
    {
        DateTime ValidaDataResgate(string dataResgate, DateTime dataAplicacao);
    }
}
