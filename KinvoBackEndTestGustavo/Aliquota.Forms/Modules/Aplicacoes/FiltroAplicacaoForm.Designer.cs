
namespace Aliquota.Forms.Modules.Aplicacoes
{
    partial class FiltroAplicacaoForm
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
            this.radioBtnTodasAplicacoes = new System.Windows.Forms.RadioButton();
            this.radioBtnAplicacaoResgatada = new System.Windows.Forms.RadioButton();
            this.radioBtnAplicacoesNaoResgatadas = new System.Windows.Forms.RadioButton();
            this.lblFiltroDeProduto = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioBtnTodasAplicacoes
            // 
            this.radioBtnTodasAplicacoes.AutoSize = true;
            this.radioBtnTodasAplicacoes.Location = new System.Drawing.Point(19, 69);
            this.radioBtnTodasAplicacoes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioBtnTodasAplicacoes.Name = "radioBtnTodasAplicacoes";
            this.radioBtnTodasAplicacoes.Size = new System.Drawing.Size(171, 17);
            this.radioBtnTodasAplicacoes.TabIndex = 3;
            this.radioBtnTodasAplicacoes.Text = "Visualizar Todas as Aplicações";
            this.radioBtnTodasAplicacoes.UseVisualStyleBackColor = true;
            // 
            // radioBtnAplicacaoResgatada
            // 
            this.radioBtnAplicacaoResgatada.AutoSize = true;
            this.radioBtnAplicacaoResgatada.Checked = true;
            this.radioBtnAplicacaoResgatada.Location = new System.Drawing.Point(19, 19);
            this.radioBtnAplicacaoResgatada.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioBtnAplicacaoResgatada.Name = "radioBtnAplicacaoResgatada";
            this.radioBtnAplicacaoResgatada.Size = new System.Drawing.Size(184, 17);
            this.radioBtnAplicacaoResgatada.TabIndex = 1;
            this.radioBtnAplicacaoResgatada.TabStop = true;
            this.radioBtnAplicacaoResgatada.Text = "Visualizar Aplicações Resgatadas";
            this.radioBtnAplicacaoResgatada.UseVisualStyleBackColor = true;
            // 
            // radioBtnAplicacoesNaoResgatadas
            // 
            this.radioBtnAplicacoesNaoResgatadas.AutoSize = true;
            this.radioBtnAplicacoesNaoResgatadas.Location = new System.Drawing.Point(19, 44);
            this.radioBtnAplicacoesNaoResgatadas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioBtnAplicacoesNaoResgatadas.Name = "radioBtnAplicacoesNaoResgatadas";
            this.radioBtnAplicacoesNaoResgatadas.Size = new System.Drawing.Size(210, 17);
            this.radioBtnAplicacoesNaoResgatadas.TabIndex = 2;
            this.radioBtnAplicacoesNaoResgatadas.Text = "Visualizar Aplicações NÃO Resgatadas";
            this.radioBtnAplicacoesNaoResgatadas.UseVisualStyleBackColor = true;
            // 
            // lblFiltroDeProduto
            // 
            this.lblFiltroDeProduto.AutoSize = true;
            this.lblFiltroDeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFiltroDeProduto.ForeColor = System.Drawing.Color.Black;
            this.lblFiltroDeProduto.Location = new System.Drawing.Point(46, 8);
            this.lblFiltroDeProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroDeProduto.Name = "lblFiltroDeProduto";
            this.lblFiltroDeProduto.Size = new System.Drawing.Size(158, 20);
            this.lblFiltroDeProduto.TabIndex = 73;
            this.lblFiltroDeProduto.Text = "Filtro de Aplicação";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnAplicacaoResgatada);
            this.groupBox1.Controls.Add(this.radioBtnAplicacoesNaoResgatadas);
            this.groupBox1.Controls.Add(this.radioBtnTodasAplicacoes);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(13, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(245, 103);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(170, 145);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 27);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmar.Location = new System.Drawing.Point(74, 145);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(88, 27);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // FiltroAplicacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 182);
            this.Controls.Add(this.lblFiltroDeProduto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FiltroAplicacaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kinvo Back End Test - Filtrar Aplicações";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioBtnTodasAplicacoes;
        private System.Windows.Forms.RadioButton radioBtnAplicacaoResgatada;
        private System.Windows.Forms.RadioButton radioBtnAplicacoesNaoResgatadas;
        private System.Windows.Forms.Label lblFiltroDeProduto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
    }
}