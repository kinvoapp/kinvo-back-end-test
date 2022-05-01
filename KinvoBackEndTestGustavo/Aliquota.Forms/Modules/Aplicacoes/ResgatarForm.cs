using Aliquota.Domain.AplicacaoModule;
using Aliquota.Domain.ProdutoModule;
using System;
using System.IO;
using System.Windows.Forms;

namespace Aliquota.Forms.Modules.Aplicacoes
{
    public partial class ResgatarForm : Form
    {
        private Aplicacao aplicacao;
        private Produto produto;

        public ResgatarForm()
        {
            InitializeComponent();
        }

        public Aplicacao Aplicacao
        {
            get { return aplicacao; }
            set
            {
                aplicacao = value;
                produto = aplicacao.Produto;

                labelAplicacaoId.Text = aplicacao.Id.ToString();
                labelAplicacaoProduto.Text = aplicacao.Produto.ToString();
                labelAplicacaoValor.Text = aplicacao.Valor.ToString();
                labelAplicacaoData.Text = aplicacao.DataAplicacao.ToString();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(labelAplicacaoId.Text);
            double valor = Convert.ToDouble(labelAplicacaoValor.Text);
            DateTime dataAplicacao = Convert.ToDateTime(labelAplicacaoData.Text);
            DateTime dataResgate = dateTPAplicacao.Value;
            double lucro = Convert.ToDouble(txtLucro.Text);

            aplicacao = new Aplicacao(id, produto, valor, dataAplicacao, dataResgate);

            double lucroFinal = aplicacao.CalcularLucro(aplicacao, lucro, dataResgate);

            string resultadoValidacao = aplicacao.Validar();

            if (resultadoValidacao != "VALIDO")
            {                
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();
                TelaPrincipal.Instancia.AtualizaRodape(primeiroErro);
                DialogResult = DialogResult.None;
            }
            else
            {
                aplicacao.Lucro = lucroFinal;
                aplicacao.CalcularFaturamento();
                ConfirmacaoOperacaoUsuario(lucro);
            }
        }

        private void ConfirmacaoOperacaoUsuario(double lucro)
        {
            DialogResult resultadoMBox = MessageBox.Show($"Valor inicial da Aplicação: R$ {aplicacao.Valor}\n" +
                                $"Lucro: R$ {lucro}\n" +
                                $"Lucro após IR: R$ {aplicacao.Lucro}\n" +
                                $"Aplicação + Lucro após IR: R$ {aplicacao.Faturamento}",
                                "Confirmar Resgate", MessageBoxButtons.YesNo);

            if (resultadoMBox == DialogResult.No)
            {
                TelaPrincipal.Instancia.AtualizaRodape("Operação cancelada pelo usuário");
                DialogResult = DialogResult.None;
            }
        }

        private void txtLucro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
