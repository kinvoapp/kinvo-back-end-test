using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aliquota.Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private class TParametroComando
        {
            public string NomeParametro { get; set; }
            public System.TypeCode TipoParametro { get; set; }

        }

        private class TComando
        {
            public string NomeComando;

            public List<TParametroComando> Parametros { get; set; } = new List<TParametroComando>();

            public Action Metodo;
        }

        private List<TComando> comandos = new List<TComando>();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.GridParametrosColunaParametroNome.DataPropertyName = "NomeParametro";
                this.GridParametrosColunaParametroTipo.DataPropertyName = "TipoParametro";

                TComando comando;

                comando = new TComando() { NomeComando = "Exemplo", Metodo = this.ExecutarExemplo };
                comando.Parametros.Add(new TParametroComando() { NomeParametro = "Nome", TipoParametro = System.TypeCode.String });
                comando.Parametros.Add(new TParametroComando() { NomeParametro = "Número", TipoParametro = System.TypeCode.Int32 });
                comandos.Add(comando);

                foreach (var item in comandos)
                {
                    this.cboAcao.Items.Add(item.NomeComando);
                }
            }
            catch (Exception l_ex)
            {
                this.txtOutput.Text = l_ex.ToString();
            }
        }


        private void cboAcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cboAcao.SelectedIndex < 0)
                {
                    this.GridParametros.DataSource = null;
                    return;
                }


                foreach (var item in comandos)
                {
                    if (this.cboAcao.SelectedItem.ToString() == item.NomeComando)
                    {
                        this.GridParametros.DataSource = item.Parametros;
                    }
                }
            }
            catch (Exception l_ex)
            {
                this.txtOutput.Text = l_ex.ToString();

            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            try
            {
                bool l_ComandoExecutado = false;
                this.txtOutput.Text = string.Empty;
                Refresh();
                System.Threading.Thread.Sleep(100);/*para que a pessoa veja o refresh;*/

                if (this.cboAcao.SelectedIndex < 0) return;

                foreach (var item in comandos)
                {
                    if (this.cboAcao.SelectedItem.ToString() == item.NomeComando)
                    {
                        if (item.Metodo != null)
                        {
                            l_ComandoExecutado = true;
                            item.Metodo();
                        }
                    }
                }

                if (l_ComandoExecutado == false) throw new IndexOutOfRangeException(String.Format("Não foi encontrado uma ação ou método para o comando {0}.", this.cboAcao.SelectedItem.ToString()));
            }
            catch (Exception l_Ex)
            {
                this.txtOutput.Text = l_Ex.ToString();
            }
        }

        private void ExecutarExemplo()
        {
            string l_ExemploValorString = this.GridParametros.Rows[0].Cells[this.GridParametrosColunaParametroValor.Name].Value.ToString();
            Int32 l_ExemploValorInt = Convert.ToInt32(this.GridParametros.Rows[1].Cells[this.GridParametrosColunaParametroValor.Name].Value.ToString());
            this.txtOutput.Text = String.Format(@"Valores: {0}, {1}", l_ExemploValorString, l_ExemploValorInt);
        }


    }
}
