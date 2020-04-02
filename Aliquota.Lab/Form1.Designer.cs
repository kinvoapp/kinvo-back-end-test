namespace Aliquota.Lab
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGO = new System.Windows.Forms.Button();
            this.cboAcao = new System.Windows.Forms.ComboBox();
            this.lblAcao = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.GridParametros = new System.Windows.Forms.DataGridView();
            this.GridParametrosColunaParametroNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridParametrosColunaParametroTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridParametrosColunaParametroValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridParametrosColunaParametroPadding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridParametros)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(697, 260);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 23);
            this.btnGO.TabIndex = 3;
            this.btnGO.Text = "Executar";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // cboAcao
            // 
            this.cboAcao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAcao.FormattingEnabled = true;
            this.cboAcao.Location = new System.Drawing.Point(12, 77);
            this.cboAcao.Name = "cboAcao";
            this.cboAcao.Size = new System.Drawing.Size(760, 21);
            this.cboAcao.TabIndex = 1;
            this.cboAcao.SelectedIndexChanged += new System.EventHandler(this.cboAcao_SelectedIndexChanged);
            // 
            // lblAcao
            // 
            this.lblAcao.AutoSize = true;
            this.lblAcao.Location = new System.Drawing.Point(12, 61);
            this.lblAcao.Name = "lblAcao";
            this.lblAcao.Size = new System.Drawing.Size(98, 13);
            this.lblAcao.TabIndex = 4;
            this.lblAcao.Text = "Ação ou Comando:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(12, 25);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(345, 20);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Text = "sistema";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nome do Usuário";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(15, 289);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(757, 352);
            this.txtOutput.TabIndex = 7;
            // 
            // GridParametros
            // 
            this.GridParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridParametros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridParametrosColunaParametroNome,
            this.GridParametrosColunaParametroTipo,
            this.GridParametrosColunaParametroValor,
            this.GridParametrosColunaParametroPadding});
            this.GridParametros.Location = new System.Drawing.Point(12, 104);
            this.GridParametros.Name = "GridParametros";
            this.GridParametros.Size = new System.Drawing.Size(760, 150);
            this.GridParametros.TabIndex = 8;
            // 
            // GridParametrosColunaParametroNome
            // 
            this.GridParametrosColunaParametroNome.HeaderText = "Parâmetro";
            this.GridParametrosColunaParametroNome.Name = "GridParametrosColunaParametroNome";
            this.GridParametrosColunaParametroNome.ReadOnly = true;
            this.GridParametrosColunaParametroNome.Width = 250;
            // 
            // GridParametrosColunaParametroTipo
            // 
            this.GridParametrosColunaParametroTipo.HeaderText = "Tipo de dado";
            this.GridParametrosColunaParametroTipo.Name = "GridParametrosColunaParametroTipo";
            this.GridParametrosColunaParametroTipo.ReadOnly = true;
            this.GridParametrosColunaParametroTipo.Width = 160;
            // 
            // GridParametrosColunaParametroValor
            // 
            this.GridParametrosColunaParametroValor.HeaderText = "Valor";
            this.GridParametrosColunaParametroValor.Name = "GridParametrosColunaParametroValor";
            this.GridParametrosColunaParametroValor.Width = 250;
            // 
            // GridParametrosColunaParametroPadding
            // 
            this.GridParametrosColunaParametroPadding.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GridParametrosColunaParametroPadding.HeaderText = "";
            this.GridParametrosColunaParametroPadding.Name = "GridParametrosColunaParametroPadding";
            this.GridParametrosColunaParametroPadding.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 650);
            this.Controls.Add(this.GridParametros);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblAcao);
            this.Controls.Add(this.cboAcao);
            this.Controls.Add(this.btnGO);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridParametros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.ComboBox cboAcao;
        private System.Windows.Forms.Label lblAcao;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.DataGridView GridParametros;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridParametrosColunaParametroNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridParametrosColunaParametroTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridParametrosColunaParametroValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridParametrosColunaParametroPadding;
    }
}

