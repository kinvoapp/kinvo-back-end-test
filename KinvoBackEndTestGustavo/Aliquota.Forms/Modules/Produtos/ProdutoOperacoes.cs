using Aliquota.Applications.Modules;
using Aliquota.Domain.ProdutoModule;
using Aliquota.Forms.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aliquota.Forms.Modules.Produtos
{
    class ProdutoOperacoes : IRegisterable
    {
        private readonly ProdutoApplication produtoApplication;
        private readonly ProdutoControlTable produtoTable = null;

        public ProdutoOperacoes(ProdutoApplication produtoApplication)
        {
            this.produtoApplication = produtoApplication;
            produtoTable = new ProdutoControlTable();
        }

        public void AddNovoRegistro()
        {
            ProdutoForm screen = new();

            if (screen.ShowDialog() == DialogResult.OK)
            {
                bool result = produtoApplication.AddEntidade(screen.Produto);
                                
                if (result)
                    TelaPrincipal.Instancia.AtualizaRodape($"Produto: {screen.Produto.Nome} criado com sucesso");
                else
                    TelaPrincipal.Instancia.AtualizaRodape($"Não foi possivel criar o produto: {screen.Produto.Nome}");

                List<Produto> services = produtoApplication.SelecionarTodasEntidades();
                produtoTable.AtualizarRegistros(services);
            }
        }

        public UserControl ObterTabela()
        {
            List<Produto> produtos = produtoApplication.SelecionarTodasEntidades();
            produtoTable.AtualizarRegistros(produtos);
            return produtoTable;
        }

        public void DeletarRegistro()
        {
            throw new NotImplementedException();
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void ResgatarRegistro()
        {
            throw new NotImplementedException();
        }
    }
}
