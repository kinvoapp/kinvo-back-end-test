using Aliquota.Domain.Domain.AgregadoResgate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Domain.AgregadoProduto
{
    public interface IProdutoService
    {
        Resgate ResgatarRendimentos(Produto produto, decimal valor, DateTime data);

    }
}
