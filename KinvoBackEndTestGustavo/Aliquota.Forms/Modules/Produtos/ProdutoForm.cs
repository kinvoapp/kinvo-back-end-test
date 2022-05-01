using Aliquota.Domain.ProdutoModule;
using System;
using System.IO;
using System.Windows.Forms;

namespace Aliquota.Forms.Modules.Produtos
{
    public partial class ProdutoForm : Form
    {
        private Produto produto;
        public ProdutoForm()
        {
            InitializeComponent();
        }

        public Produto Produto
        {
            get { return produto; }
            set
            {
                produto = value;

                txtNome.Text = produto.Nome;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int id = 0;
            string nome = txtNome.Text;

            produto = new Produto(id, nome);

            string resultadoValidacao = produto.Validar();

            if (resultadoValidacao != "VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();
                TelaPrincipal.Instancia.AtualizaRodape(primeiroErro);
                DialogResult = DialogResult.None;
            }
        }
    }
}
