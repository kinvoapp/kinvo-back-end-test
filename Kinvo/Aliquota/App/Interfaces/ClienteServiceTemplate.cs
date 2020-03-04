// ===================================================================
//  Autor: Valnei Filho
//  E-mail: v_marinpietri@yahoo.com.br, 719946-7636
//  Data Criação: 04/03/2020
// ===================================================================


using System;
using System.Collections.Generic;
using Aliquota.Domain;

namespace Aliquota.App.Interfaces
{
    public abstract class ClienteServiceTemplate
    {
        #region Propriedades

        public List<Produto> Produtos { get; private set; }

        public Cliente Cliente { get;} 

        #endregion

        public ClienteServiceTemplate(Cliente cliente)
        {
            Cliente = cliente;
        }

        /// <summary>
        /// Realizar Aplicação
        /// </summary>
        /// <param name="produto"></param>
        public void Aplicar(List<Produto> produto)
        {
            var list = new List<Produto>();
            int i = 1;
            produto.ForEach(item =>
            {
                if (item.Saldo <= 0)
                    throw new InvalidOperationException("A aplicação neste produto não pode ser igual ou menor que zero");
                item.Id = i;

                list.Add(item);
                i++;
            });
            Produtos = list;
        }

        /// <summary>
        /// Realizar Resgate
        /// </summary>
        /// <param name="valorResgate"></param>
        /// <param name="produtoId"></param>
        /// <param name="dataResgate"></param>
        /// <returns></returns>
        public abstract InformacaoFiscal Resgatar(decimal valorResgate, int produtoId, DateTime dataResgate);

         

    }
}