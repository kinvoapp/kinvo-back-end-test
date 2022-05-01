
namespace Aliquota.Forms
{
    partial class TelaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aplicacaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBoxAcoes = new System.Windows.Forms.ToolStrip();
            this.SBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.SBtnResgatar = new System.Windows.Forms.ToolStripButton();
            this.SBtnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SLblOperacao = new System.Windows.Forms.ToolStripLabel();
            this.painelRegistros = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.toolBoxAcoes.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtoToolStripMenuItem,
            this.aplicacaoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.produtoToolStripMenuItem.Text = "Produto";
            this.produtoToolStripMenuItem.Click += new System.EventHandler(this.produtoToolStripMenuItem_Click);
            // 
            // aplicacaoToolStripMenuItem
            // 
            this.aplicacaoToolStripMenuItem.Name = "aplicacaoToolStripMenuItem";
            this.aplicacaoToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.aplicacaoToolStripMenuItem.Text = "Aplicação";
            this.aplicacaoToolStripMenuItem.Click += new System.EventHandler(this.aplicacaoToolStripMenuItem_Click);
            // 
            // toolBoxAcoes
            // 
            this.toolBoxAcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SBtnAdd,
            this.SBtnResgatar,
            this.SBtnFiltrar,
            this.toolStripSeparator1,
            this.SLblOperacao});
            this.toolBoxAcoes.Location = new System.Drawing.Point(0, 24);
            this.toolBoxAcoes.Name = "toolBoxAcoes";
            this.toolBoxAcoes.Size = new System.Drawing.Size(800, 31);
            this.toolBoxAcoes.TabIndex = 1;
            this.toolBoxAcoes.Text = "toolStrip1";
            // 
            // SBtnAdd
            // 
            this.SBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("SBtnAdd.Image")));
            this.SBtnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SBtnAdd.Name = "SBtnAdd";
            this.SBtnAdd.Size = new System.Drawing.Size(28, 28);
            this.SBtnAdd.Click += new System.EventHandler(this.SBtnAdd_Click);
            // 
            // SBtnResgatar
            // 
            this.SBtnResgatar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SBtnResgatar.Image = ((System.Drawing.Image)(resources.GetObject("SBtnResgatar.Image")));
            this.SBtnResgatar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SBtnResgatar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SBtnResgatar.Name = "SBtnResgatar";
            this.SBtnResgatar.Size = new System.Drawing.Size(28, 28);
            this.SBtnResgatar.Click += new System.EventHandler(this.SBtnResgatar_Click);
            // 
            // SBtnFiltrar
            // 
            this.SBtnFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SBtnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("SBtnFiltrar.Image")));
            this.SBtnFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SBtnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SBtnFiltrar.Name = "SBtnFiltrar";
            this.SBtnFiltrar.Size = new System.Drawing.Size(28, 28);
            this.SBtnFiltrar.Click += new System.EventHandler(this.SBtnFiltrar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // SLblOperacao
            // 
            this.SLblOperacao.Name = "SLblOperacao";
            this.SLblOperacao.Size = new System.Drawing.Size(73, 28);
            this.SLblOperacao.Text = "Hello World!";
            // 
            // painelRegistros
            // 
            this.painelRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painelRegistros.Location = new System.Drawing.Point(0, 55);
            this.painelRegistros.Name = "painelRegistros";
            this.painelRegistros.Size = new System.Drawing.Size(800, 395);
            this.painelRegistros.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLbl
            // 
            this.toolStripStatusLbl.Name = "toolStripStatusLbl";
            this.toolStripStatusLbl.Size = new System.Drawing.Size(73, 17);
            this.toolStripStatusLbl.Text = "Hello World!";
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.painelRegistros);
            this.Controls.Add(this.toolBoxAcoes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TelaPrincipal";
            this.Text = "Kinvo Back End Test";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolBoxAcoes.ResumeLayout(false);
            this.toolBoxAcoes.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolBoxAcoes;
        private System.Windows.Forms.ToolStripButton SBtnAdd;
        private System.Windows.Forms.ToolStripButton SBtnResgatar;
        private System.Windows.Forms.ToolStripMenuItem aplicacaoToolStripMenuItem;
        private System.Windows.Forms.Panel painelRegistros;
        private System.Windows.Forms.ToolStripButton SBtnFiltrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel SLblOperacao;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLbl;
    }
}

