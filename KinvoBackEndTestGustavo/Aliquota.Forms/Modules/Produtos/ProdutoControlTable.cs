using Aliquota.Domain.ProdutoModule;
using Aliquota.Forms.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aliquota.Forms.Modules.Produtos
{
    public partial class ProdutoControlTable : UserControl
    {
        public ProdutoControlTable()
        {
            InitializeComponent();
            dataGridProduto.ConfigZebraColorStyling();
            dataGridProduto.ConfigGridReadOnly();
            dataGridProduto.Columns.AddRange(ObtainColumns());
        }

        public DataGridViewColumn[] ObtainColumns()
        {
            var columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" }
            };
            return columns;
        }

        public int ObtainIdSelected()
        {
            return dataGridProduto.SelectId<int>();
        }

        public void AtualizarRegistros(List<Produto> produtos)
        {
            dataGridProduto.Rows.Clear();

            foreach (Produto produto in produtos)
                dataGridProduto.Rows.Add(produto.Id, produto.Nome);
        }
    }
}
