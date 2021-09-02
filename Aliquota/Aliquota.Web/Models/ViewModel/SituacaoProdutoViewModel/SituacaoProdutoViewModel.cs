using Aliquota.Domain.Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Web.Models.ViewModel.SituacaoProdutoViewModel
{
    public class SituacaoProdutoViewModel
    {
        public int IdSituacaoProduto { get; set; }
        public string Situacao { get; set; }

        public SituacaoProdutoViewModel()
        {
        }
        public void InitView(SituacaoProduto situacaoProduto)
        {
            IdSituacaoProduto = situacaoProduto.Id;
            Situacao = situacaoProduto.Situacao;
        }


    }
}
