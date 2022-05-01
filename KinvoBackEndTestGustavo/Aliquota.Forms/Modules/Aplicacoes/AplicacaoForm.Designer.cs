
namespace Aliquota.Forms.Modules.Aplicacoes
{
    partial class AplicacaoForm
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
            this.lblRegistroDeProduto = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxProdutos = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.labelValor = new System.Windows.Forms.Label();
            this.labelDataAplicacao = new System.Windows.Forms.Label();
            this.dateTPAplicacao = new System.Windows.Forms.DateTimePicker();
            this.labelProduto = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRegistroDeProduto
            // 
            this.lblRegistroDeProduto.AutoSize = true;
            this.lblRegistroDeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRegistroDeProduto.ForeColor = System.Drawing.Color.Black;
            this.lblRegistroDeProduto.Location = new System.Drawing.Point(66, 12);
            this.lblRegistroDeProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistroDeProduto.Name = "lblRegistroDeProduto";
            this.lblRegistroDeProduto.Size = new System.Drawing.Size(185, 20);
            this.lblRegistroDeProduto.TabIndex = 69;
            this.lblRegistroDeProduto.Text = "Registro de Aplicação";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxProdutos);
            this.groupBox1.Controls.Add(this.txtValor);
            this.groupBox1.Controls.Add(this.labelValor);
            this.groupBox1.Controls.Add(this.labelDataAplicacao);
            this.groupBox1.Controls.Add(this.dateTPAplicacao);
            this.groupBox1.Controls.Add(this.labelProduto);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(13, 40);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(291, 120);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            // 
            // comboBoxProdutos
            // 
            this.comboBoxProdutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProdutos.FormattingEnabled = true;
            this.comboBoxProdutos.Location = new System.Drawing.Point(73, 27);
            this.comboBoxProdutos.Name = "comboBoxProdutos";
            this.comboBoxProdutos.Size = new System.Drawing.Size(180, 21);
            this.comboBoxProdutos.TabIndex = 12;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(73, 54);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(180, 20);
            this.txtValor.TabIndex = 11;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(36, 57);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(31, 13);
            this.labelValor.TabIndex = 10;
            this.labelValor.Text = "Valor";
            // 
            // labelDataAplicacao
            // 
            this.labelDataAplicacao.AutoSize = true;
            this.labelDataAplicacao.Location = new System.Drawing.Point(37, 86);
            this.labelDataAplicacao.Name = "labelDataAplicacao";
            this.labelDataAplicacao.Size = new System.Drawing.Size(30, 13);
            this.labelDataAplicacao.TabIndex = 9;
            this.labelDataAplicacao.Text = "Data";
            // 
            // dateTPAplicacao
            // 
            this.dateTPAplicacao.CustomFormat = "dd/MM/yyyy";
            this.dateTPAplicacao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPAplicacao.Location = new System.Drawing.Point(73, 80);
            this.dateTPAplicacao.Name = "dateTPAplicacao";
            this.dateTPAplicacao.Size = new System.Drawing.Size(180, 20);
            this.dateTPAplicacao.TabIndex = 8;
            // 
            // labelProduto
            // 
            this.labelProduto.AutoSize = true;
            this.labelProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelProduto.ForeColor = System.Drawing.Color.Black;
            this.labelProduto.Location = new System.Drawing.Point(22, 30);
            this.labelProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProduto.Name = "labelProduto";
            this.labelProduto.Size = new System.Drawing.Size(44, 13);
            this.labelProduto.TabIndex = 0;
            this.labelProduto.Text = "Produto";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(216, 166);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 27);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmar.Location = new System.Drawing.Point(120, 166);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(88, 27);
            this.btnConfirmar.TabIndex = 66;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // AplicacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 206);
            this.Controls.Add(this.lblRegistroDeProduto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Name = "AplicacaoForm";
            this.Text = "AplicacaoForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRegistroDeProduto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelProduto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DateTimePicker dateTPAplicacao;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label labelValor;
        private System.Windows.Forms.Label labelDataAplicacao;
        private System.Windows.Forms.ComboBox comboBoxProdutos;
    }
}