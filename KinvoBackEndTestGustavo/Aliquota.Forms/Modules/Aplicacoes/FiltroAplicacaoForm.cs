using System.Windows.Forms;

namespace Aliquota.Forms.Modules.Aplicacoes
{
    public partial class FiltroAplicacaoForm : Form
    {
        public FiltroAplicacaoForm()
        {
            InitializeComponent();
        }

        public FiltroAplicacaoEnum TipoFiltro
        {
            get
            {
                if (radioBtnAplicacaoResgatada.Checked)
                    return FiltroAplicacaoEnum.AplicacoesResgatadas;
                else if (radioBtnAplicacoesNaoResgatadas.Checked)
                    return FiltroAplicacaoEnum.AplicacoesNaoResgatadas;
                else
                    return FiltroAplicacaoEnum.TodasAplicacoes;
            }
        }
    }
}
