using Aliquota.Applications.Modules;
using Aliquota.Domain.AplicacaoModule;
using Aliquota.Domain.ProdutoModule;
using System;
using System.IO;
using System.Windows.Forms;

namespace Aliquota.Forms.Modules.Aplicacoes
{
    public partial class AplicacaoForm : Form
    {
        private readonly ProdutoApplication produtoApplication;
        private Aplicacao aplicacao;
        private Produto produto;
        public AplicacaoForm(ProdutoApplication _produtoApplication)
        {
            produtoApplication = _produtoApplication;
            InitializeComponent();
            comboBoxProdutos.DataSource = produtoApplication.SelecionarTodasEntidades();
        }

        public Aplicacao Aplicacao
        {
            get { return aplicacao; }
            set
            {
                aplicacao = value;
                
                comboBoxProdutos.DataSource = aplicacao.Produto;
                dateTPAplicacao.Value = aplicacao.DataAplicacao;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int id = 0;
            DateTime dataAplicacao = dateTPAplicacao.Value;
            produto = comboBoxProdutos.SelectedItem as Produto;

            if (!double.TryParse(txtValor.Text, out double price))
                price = 0;

            aplicacao = new(id, produto, price, dataAplicacao, null);

            string resultadoValidacao = aplicacao.Validar();

            if (resultadoValidacao != "VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();
                TelaPrincipal.Instancia.AtualizaRodape(primeiroErro);
                DialogResult = DialogResult.None;
            }
        }
    }
}
