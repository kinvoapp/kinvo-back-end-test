using Aliquota.Domain.Domain.AgregadoResgate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aliquota.Domain.Domain.AgregadoProduto
{
    public class ProdutoService : IProdutoService
    {
        public Resgate ResgatarRendimentos(Produto produto, decimal valor, DateTime data)
        {
            
            produto.ResgatarRendimentos(valor, data);

            return null;

        }
    }
}
