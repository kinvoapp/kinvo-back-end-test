namespace Aliquota.Domain
{
    partial class Frm_Aliquota
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
            this.btn_Resgatar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Aplicação = new System.Windows.Forms.ComboBox();
            this.lbl_Lucro = new System.Windows.Forms.Label();
            this.lbl_DataAtual = new System.Windows.Forms.Label();
            this.txt_Valor = new System.Windows.Forms.TextBox();
            this.txt_Data = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Aliquota = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_IR = new System.Windows.Forms.Label();
            this.txt_DataResgate = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Resgatar
            // 
            this.btn_Resgatar.Location = new System.Drawing.Point(713, 415);
            this.btn_Resgatar.Name = "btn_Resgatar";
            this.btn_Resgatar.Size = new System.Drawing.Size(75, 23);
            this.btn_Resgatar.TabIndex = 0;
            this.btn_Resgatar.Text = "Resgatar";
            this.btn_Resgatar.UseVisualStyleBackColor = true;
            this.btn_Resgatar.Click += new System.EventHandler(this.btn_Resgatar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lucro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aplicação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data da Aplicação";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Valor";
            // 
            // cmb_Aplicação
            // 
            this.cmb_Aplicação.FormattingEnabled = true;
            this.cmb_Aplicação.Items.AddRange(new object[] {
            "Tesouro Direto",
            "CDB",
            "LCI/LCA"});
            this.cmb_Aplicação.Location = new System.Drawing.Point(190, 105);
            this.cmb_Aplicação.Name = "cmb_Aplicação";
            this.cmb_Aplicação.Size = new System.Drawing.Size(121, 23);
            this.cmb_Aplicação.TabIndex = 3;
            this.cmb_Aplicação.Text = "Aplicação";
            // 
            // lbl_Lucro
            // 
            this.lbl_Lucro.AutoSize = true;
            this.lbl_Lucro.Location = new System.Drawing.Point(395, 67);
            this.lbl_Lucro.Name = "lbl_Lucro";
            this.lbl_Lucro.Size = new System.Drawing.Size(44, 15);
            this.lbl_Lucro.TabIndex = 4;
            this.lbl_Lucro.Text = "R$ 0,00";
            // 
            // lbl_DataAtual
            // 
            this.lbl_DataAtual.AutoSize = true;
            this.lbl_DataAtual.Location = new System.Drawing.Point(713, 397);
            this.lbl_DataAtual.Name = "lbl_DataAtual";
            this.lbl_DataAtual.Size = new System.Drawing.Size(62, 15);
            this.lbl_DataAtual.TabIndex = 1;
            this.lbl_DataAtual.Text = "Data Atual";
            // 
            // txt_Valor
            // 
            this.txt_Valor.Location = new System.Drawing.Point(190, 64);
            this.txt_Valor.Name = "txt_Valor";
            this.txt_Valor.Size = new System.Drawing.Size(120, 23);
            this.txt_Valor.TabIndex = 7;
            this.txt_Valor.TextChanged += new System.EventHandler(this.txt_Valor_TextChanged);
            this.txt_Valor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Valor_KeyPress);
            // 
            // txt_Data
            // 
            this.txt_Data.Location = new System.Drawing.Point(191, 155);
            this.txt_Data.Mask = "00/00/0000";
            this.txt_Data.Name = "txt_Data";
            this.txt_Data.Size = new System.Drawing.Size(100, 23);
            this.txt_Data.TabIndex = 8;
            this.txt_Data.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_Data_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Aliquota:";
            // 
            // lbl_Aliquota
            // 
            this.lbl_Aliquota.AutoSize = true;
            this.lbl_Aliquota.Location = new System.Drawing.Point(395, 108);
            this.lbl_Aliquota.Name = "lbl_Aliquota";
            this.lbl_Aliquota.Size = new System.Drawing.Size(23, 15);
            this.lbl_Aliquota.TabIndex = 4;
            this.lbl_Aliquota.Text = "0%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(365, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "IR:";
            // 
            // lbl_IR
            // 
            this.lbl_IR.AutoSize = true;
            this.lbl_IR.Location = new System.Drawing.Point(395, 145);
            this.lbl_IR.Name = "lbl_IR";
            this.lbl_IR.Size = new System.Drawing.Size(29, 15);
            this.lbl_IR.TabIndex = 4;
            this.lbl_IR.Text = "R$ 0";
            // 
            // txt_DataResgate
            // 
            this.txt_DataResgate.Location = new System.Drawing.Point(191, 200);
            this.txt_DataResgate.Mask = "00/00/0000";
            this.txt_DataResgate.Name = "txt_DataResgate";
            this.txt_DataResgate.Size = new System.Drawing.Size(100, 23);
            this.txt_DataResgate.TabIndex = 8;
            this.txt_DataResgate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_DataResgate_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Data do Resgate";
            // 
            // Frm_Aliquota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_DataResgate);
            this.Controls.Add(this.lbl_IR);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_Aliquota);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Data);
            this.Controls.Add(this.txt_Valor);
            this.Controls.Add(this.lbl_DataAtual);
            this.Controls.Add(this.lbl_Lucro);
            this.Controls.Add(this.cmb_Aplicação);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Resgatar);
            this.Name = "Frm_Aliquota";
            this.Text = "Aliquota";
            this.Load += new System.EventHandler(this.Frm_Aliquota_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Resgatar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Aplicação;
        private System.Windows.Forms.Label lbl_Lucro;
        private System.Windows.Forms.Label lbl_DataAtual;
        private System.Windows.Forms.TextBox txt_Valor;
        private System.Windows.Forms.MaskedTextBox txt_Data;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Aliquota;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_IR;
        private System.Windows.Forms.MaskedTextBox txt_DataResgate;
        private System.Windows.Forms.Label label6;
    }
}

