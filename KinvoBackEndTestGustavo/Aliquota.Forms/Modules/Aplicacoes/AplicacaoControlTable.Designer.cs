
namespace Aliquota.Forms.Modules.Aplicacoes
{
    partial class AplicacaoControlTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridAplicacao = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAplicacao)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridAplicacao
            // 
            this.dataGridAplicacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAplicacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAplicacao.Location = new System.Drawing.Point(0, 0);
            this.dataGridAplicacao.Name = "dataGridAplicacao";
            this.dataGridAplicacao.RowTemplate.Height = 25;
            this.dataGridAplicacao.Size = new System.Drawing.Size(150, 150);
            this.dataGridAplicacao.TabIndex = 0;
            // 
            // AplicacaoControlTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridAplicacao);
            this.Name = "AplicacaoControlTable";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAplicacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridAplicacao;
    }
}
