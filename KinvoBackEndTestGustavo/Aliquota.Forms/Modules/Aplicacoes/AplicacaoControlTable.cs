using Aliquota.Domain.AplicacaoModule;
using Aliquota.Forms.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aliquota.Forms.Modules.Aplicacoes
{
    public partial class AplicacaoControlTable : UserControl
    {
        public AplicacaoControlTable()
        {
            InitializeComponent();
            dataGridAplicacao.ConfigZebraColorStyling();
            dataGridAplicacao.ConfigGridReadOnly();
            dataGridAplicacao.Columns.AddRange(ObtainColumns());
        }

        public DataGridViewColumn[] ObtainColumns()
        {
            var columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Produto", HeaderText = "Produto" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Aplicacao", HeaderText = "Aplicação" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Resgate", HeaderText = "Resgate" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Lucro", HeaderText = "Lucro" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Faturamento", HeaderText = "Faturamento" }
            };
            return columns;
        }

        public int ObtainIdSelected()
        {
            return dataGridAplicacao.SelectId<int>();
        }

        public void AtualizarRegistros(List<Aplicacao> aplicacoes)
        {
            dataGridAplicacao.Rows.Clear();

            dataGridAplicacao.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridAplicacao.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";

            foreach (Aplicacao aplicacao in aplicacoes)
            {
                dataGridAplicacao.Rows.Add(
                    aplicacao.Id,
                    aplicacao.Produto.Nome.ToString(),
                    aplicacao.Valor, 
                    aplicacao.DataAplicacao,
                    aplicacao.DataResgate,
                    aplicacao.Lucro,
                    aplicacao.Faturamento);
            }
        }
    }
}
