using Aliquota.Forms.Modules.Aplicacoes;
using Aliquota.Forms.Modules.Produtos;
using Aliquota.Forms.Shared;
using Aliquota.Infrastructure;
using Autofac;
using System;
using System.Windows.Forms;

namespace Aliquota.Forms
{
    public partial class TelaPrincipal : Form
    {
        private IRegisterable operacoes;
        private static TelaPrincipal instancia;
        private readonly AliquotaDBContext db;

        public static TelaPrincipal Instancia { get => instancia; set => instancia = value; }

        public TelaPrincipal()
        {
            InitializeComponent();
            instancia = this;
            db = new();
            CarregaInfosIniciais();
        }

        #region Botões MenuStrip
        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProdutoToolBoxConfig configuracao = new();
            ToolBoxConfiguration(configuracao, false);
            AtualizaRodape(configuracao.TipoRegistro);
            operacoes = AutoFac.Container.Resolve<ProdutoOperacoes>();
            ConfigurarRegistrosPainel();
        }

        private void aplicacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AplicacaoToolBoxConfig configuracao = new();
            ToolBoxConfiguration(configuracao, true);
            AtualizaRodape(configuracao.TipoRegistro);
            operacoes = AutoFac.Container.Resolve<AplicacaoOperacoes>();
            ConfigurarRegistrosPainel();
        }
        #endregion        

        #region Botões ToolStrip
        private void SBtnAdd_Click(object sender, EventArgs e)
        {
            operacoes.AddNovoRegistro();
        }

        private void SBtnResgatar_Click(object sender, EventArgs e)
        {
            operacoes.ResgatarRegistro();
        }

        private void SBtnFiltrar_Click(object sender, EventArgs e)
        {
            operacoes.FiltrarRegistros();
        }
        #endregion

        #region Métodos Privados
        private void ToolBoxConfiguration(IConfigurationToolBox configuracao, bool todasPermissoes)
        {
            toolBoxAcoes.Enabled = true;

            if (todasPermissoes)
            {
                SBtnResgatar.Enabled = true;
                SBtnFiltrar.Enabled = true;
            }
            else
            {
                SBtnResgatar.Enabled = false;
                SBtnFiltrar.Enabled = false;
            }

            SLblOperacao.Text = configuracao.TipoRegistro;
            SBtnAdd.ToolTipText = configuracao.ToolTipAdd;
        }

        public void AtualizaRodape(string primeiroErro)
        {
            toolStripStatusLbl.Text = primeiroErro;
        }

        private void ConfigurarRegistrosPainel()
        {
            UserControl table = operacoes.ObterTabela();
            table.Dock = DockStyle.Fill;
            painelRegistros.Controls.Clear();
            painelRegistros.Controls.Add(table);
        }

        private void CarregaInfosIniciais()
        {
            SLblOperacao.Text = "Kinvo";
            toolBoxAcoes.Enabled = false;
            AtualizaRodape("By Gustavo Mariano");
        }
        #endregion
    }
}
