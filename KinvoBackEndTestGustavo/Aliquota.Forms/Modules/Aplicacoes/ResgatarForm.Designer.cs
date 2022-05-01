
namespace Aliquota.Forms.Modules.Aplicacoes
{
    partial class ResgatarForm
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
            this.txtLucro = new System.Windows.Forms.TextBox();
            this.labelLucro = new System.Windows.Forms.Label();
            this.dateTPAplicacao = new System.Windows.Forms.DateTimePicker();
            this.labelAplicacaoData = new System.Windows.Forms.Label();
            this.labelAplicacaoValor = new System.Windows.Forms.Label();
            this.labelAplicacaoProduto = new System.Windows.Forms.Label();
            this.labelAplicacaoId = new System.Windows.Forms.Label();
            this.labelDataResgate = new System.Windows.Forms.Label();
            this.labelValor = new System.Windows.Forms.Label();
            this.labelDataAplicacao = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
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
            this.lblRegistroDeProduto.Location = new System.Drawing.Point(75, 14);
            this.lblRegistroDeProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistroDeProduto.Name = "lblRegistroDeProduto";
            this.lblRegistroDeProduto.Size = new System.Drawing.Size(166, 20);
            this.lblRegistroDeProduto.TabIndex = 73;
            this.lblRegistroDeProduto.Text = "Resgatar Aplicação";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLucro);
            this.groupBox1.Controls.Add(this.labelLucro);
            this.groupBox1.Controls.Add(this.dateTPAplicacao);
            this.groupBox1.Controls.Add(this.labelAplicacaoData);
            this.groupBox1.Controls.Add(this.labelAplicacaoValor);
            this.groupBox1.Controls.Add(this.labelAplicacaoProduto);
            this.groupBox1.Controls.Add(this.labelAplicacaoId);
            this.groupBox1.Controls.Add(this.labelDataResgate);
            this.groupBox1.Controls.Add(this.labelValor);
            this.groupBox1.Controls.Add(this.labelDataAplicacao);
            this.groupBox1.Controls.Add(this.labelId);
            this.groupBox1.Controls.Add(this.labelProduto);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(13, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(291, 199);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            // 
            // txtLucro
            // 
            this.txtLucro.Location = new System.Drawing.Point(122, 158);
            this.txtLucro.Name = "txtLucro";
            this.txtLucro.Size = new System.Drawing.Size(133, 20);
            this.txtLucro.TabIndex = 2;
            this.txtLucro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLucro_KeyPress);
            // 
            // labelLucro
            // 
            this.labelLucro.AutoSize = true;
            this.labelLucro.Location = new System.Drawing.Point(32, 161);
            this.labelLucro.Name = "labelLucro";
            this.labelLucro.Size = new System.Drawing.Size(34, 13);
            this.labelLucro.TabIndex = 19;
            this.labelLucro.Text = "Lucro";
            // 
            // dateTPAplicacao
            // 
            this.dateTPAplicacao.CustomFormat = "dd/MM/yyyy";
            this.dateTPAplicacao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPAplicacao.Location = new System.Drawing.Point(122, 132);
            this.dateTPAplicacao.Name = "dateTPAplicacao";
            this.dateTPAplicacao.Size = new System.Drawing.Size(133, 20);
            this.dateTPAplicacao.TabIndex = 1;
            // 
            // labelAplicacaoData
            // 
            this.labelAplicacaoData.AutoSize = true;
            this.labelAplicacaoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAplicacaoData.Location = new System.Drawing.Point(116, 110);
            this.labelAplicacaoData.Name = "labelAplicacaoData";
            this.labelAplicacaoData.Size = new System.Drawing.Size(145, 16);
            this.labelAplicacaoData.TabIndex = 17;
            this.labelAplicacaoData.Text = "labelAplicacaoData";
            // 
            // labelAplicacaoValor
            // 
            this.labelAplicacaoValor.AutoSize = true;
            this.labelAplicacaoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAplicacaoValor.Location = new System.Drawing.Point(178, 81);
            this.labelAplicacaoValor.Name = "labelAplicacaoValor";
            this.labelAplicacaoValor.Size = new System.Drawing.Size(44, 16);
            this.labelAplicacaoValor.TabIndex = 16;
            this.labelAplicacaoValor.Text = "Valor";
            // 
            // labelAplicacaoProduto
            // 
            this.labelAplicacaoProduto.AutoSize = true;
            this.labelAplicacaoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAplicacaoProduto.Location = new System.Drawing.Point(170, 52);
            this.labelAplicacaoProduto.Name = "labelAplicacaoProduto";
            this.labelAplicacaoProduto.Size = new System.Drawing.Size(61, 16);
            this.labelAplicacaoProduto.TabIndex = 15;
            this.labelAplicacaoProduto.Text = "Produto";
            // 
            // labelAplicacaoId
            // 
            this.labelAplicacaoId.AutoSize = true;
            this.labelAplicacaoId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAplicacaoId.Location = new System.Drawing.Point(190, 23);
            this.labelAplicacaoId.Name = "labelAplicacaoId";
            this.labelAplicacaoId.Size = new System.Drawing.Size(20, 16);
            this.labelAplicacaoId.TabIndex = 14;
            this.labelAplicacaoId.Text = "Id";
            // 
            // labelDataResgate
            // 
            this.labelDataResgate.AutoSize = true;
            this.labelDataResgate.Location = new System.Drawing.Point(19, 138);
            this.labelDataResgate.Name = "labelDataResgate";
            this.labelDataResgate.Size = new System.Drawing.Size(47, 13);
            this.labelDataResgate.TabIndex = 13;
            this.labelDataResgate.Text = "Resgate";
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(35, 83);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(31, 13);
            this.labelValor.TabIndex = 10;
            this.labelValor.Text = "Valor";
            // 
            // labelDataAplicacao
            // 
            this.labelDataAplicacao.AutoSize = true;
            this.labelDataAplicacao.Location = new System.Drawing.Point(15, 112);
            this.labelDataAplicacao.Name = "labelDataAplicacao";
            this.labelDataAplicacao.Size = new System.Drawing.Size(54, 13);
            this.labelDataAplicacao.TabIndex = 9;
            this.labelDataAplicacao.Text = "Aplicação";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelId.ForeColor = System.Drawing.Color.Black;
            this.labelId.Location = new System.Drawing.Point(50, 25);
            this.labelId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(16, 13);
            this.labelId.TabIndex = 7;
            this.labelId.Text = "Id";
            // 
            // labelProduto
            // 
            this.labelProduto.AutoSize = true;
            this.labelProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelProduto.ForeColor = System.Drawing.Color.Black;
            this.labelProduto.Location = new System.Drawing.Point(22, 54);
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
            this.btnCancelar.Location = new System.Drawing.Point(216, 247);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 27);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmar.Location = new System.Drawing.Point(120, 247);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(88, 27);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // ResgatarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 287);
            this.Controls.Add(this.lblRegistroDeProduto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResgatarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kinvo Back End Test - Resgatar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRegistroDeProduto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelValor;
        private System.Windows.Forms.Label labelDataAplicacao;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelProduto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label labelAplicacaoData;
        private System.Windows.Forms.Label labelAplicacaoValor;
        private System.Windows.Forms.Label labelAplicacaoProduto;
        private System.Windows.Forms.Label labelAplicacaoId;
        private System.Windows.Forms.Label labelDataResgate;
        private System.Windows.Forms.TextBox txtLucro;
        private System.Windows.Forms.Label labelLucro;
        private System.Windows.Forms.DateTimePicker dateTPAplicacao;
    }
}