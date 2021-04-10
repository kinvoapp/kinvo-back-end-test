using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliquota.Domain
{
    public partial class Frm_Aliquota : Form
    {
        public Frm_Aliquota()
        {
            InitializeComponent();
        }
        private DateTime data;
        private double lucro;
        private double aliquota;

        private void Frm_Aliquota_Load(object sender, EventArgs e)
        {
            txt_Valor.Text = "R$";
            data = DateTime.Today;
            lbl_DataAtual.Text = data.ToString("d");
            txt_DataResgate.Text = data.Date.ToString();

        }
        private void txt_Valor_TextChanged(object sender, EventArgs e)
        {
            string valor = txt_Valor.Text.Replace(",", "").Replace("R$", "").Replace(".", "").TrimStart('0');
            decimal ul;
            if (decimal.TryParse(valor, out ul))
            {
                ul /= 100;
                txt_Valor.TextChanged -= txt_Valor_TextChanged;
                txt_Valor.Text = string.Format(CultureInfo.CreateSpecificCulture("pt-BR"), "{0:C2}", ul);
                txt_Valor.TextChanged += txt_Valor_TextChanged;
                txt_Valor.Select(txt_Valor.Text.Length, 0);
            }
        }

        private void txt_Valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btn_Resgatar_Click(object sender, EventArgs e)
        {
            if (cmb_Aplicação.SelectedItem == "Tesouro Direto")
            {
                lucro = calculaLucro(0.088);
                lbl_Lucro.Text = "R$ " + lucro.ToString();
            }
            if (cmb_Aplicação.SelectedItem == "CDB")
            {
                lucro = calculaLucro(0.015);
                lbl_Lucro.Text = "R$ " + lucro.ToString();
            }
            if (cmb_Aplicação.SelectedItem == "LCI/LCA")
            {
                lucro = calculaLucro(0.065);
                lbl_Lucro.Text = "R$ " + lucro.ToString();
            }
            lbl_IR.Text = "R$ " + (lucro * aliquota).ToString();
        }
        private double calculaLucro(double taxaAnual)
        {
            double valor = 0;
            try
            {
                valor = double.Parse(txt_Valor.Text.Replace("R$", "").Replace(".", "").TrimStart('0'));
            }
            catch(Exception e) { }

            if (valor > 0)
            {
                try
                {
                    DateTime dataAplicacao = DateTime.ParseExact(txt_Data.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                    TimeSpan tempo = (data - dataAplicacao) / 365;

                    if (tempo.Days < 0)
                    {
                        MessageBox.Show("Data Inválida");
                        return 0;
                    }

                    if (tempo.Days < 1)
                    {
                        lbl_Aliquota.Text = "22,5%";
                        aliquota = 0.225;
                    }
                    else if (tempo.Days <= 2)
                    {
                        lbl_Aliquota.Text = "18,5%";
                        aliquota = 0.185;
                    }
                    else if (tempo.Days > 2)
                    {
                        lbl_Aliquota.Text = "15%";
                        aliquota = 0.15;
                    }
                   
                    return valor * taxaAnual * tempo.Days;
                }
                catch (Exception e) 
                {
                    MessageBox.Show("Data Inválida");
                    return 0; 
                }
            }
            else
            {
                MessageBox.Show("Valor inválido");
                return 0;
            }
        }

        private void txt_Data_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_Data.Text == "  /  /")
                txt_Data.Select(0, 0);
        }

        private void txt_DataResgate_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_DataResgate.Text == "  /  /")
                txt_DataResgate.Select(0, 0);
        }
    }
}
