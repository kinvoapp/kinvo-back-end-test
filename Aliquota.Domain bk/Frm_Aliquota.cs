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
        private DateTime dataResgate;
        private DateTime dataAplicacao;

        private void Frm_Aliquota_Load(object sender, EventArgs e)
        {
            txt_Valor.Text = "R$";
            dataResgate = DateTime.Today;
            //lbl_DataAtual.Text = data.ToString("d");
            txt_DataResgate.Text = dataResgate.Date.ToString();
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
            dataAplicacao = DateTime.ParseExact(txt_Data.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
            dataResgate = DateTime.ParseExact(txt_DataResgate.Text, "d/M/yyyy", CultureInfo.InvariantCulture);

            double valor = double.Parse(txt_Valor.Text.Replace("R$", "").Replace(".", ""));
            double taxa = 0;

            if (cmb_Aplicação.SelectedItem == "Tesouro Direto")
            {
                taxa = 0.088;
            }
            if (cmb_Aplicação.SelectedItem == "CDB")
            {
                taxa = 0.015;
            }
            if (cmb_Aplicação.SelectedItem == "LCI/LCA")
            {
                taxa = 0.065;  
            }

            IR ir = new IR();
            ir.lucro = new Lucro(dataResgate, dataAplicacao, taxa, valor);

            lbl_Aliquota.Text = ir.lucro.getAliquota().ToString();
            lbl_Lucro.Text = "R$ " + ir.lucro.getLucro().ToString();
            lbl_IR.Text = "R$ " + ir.getIR().ToString();
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
