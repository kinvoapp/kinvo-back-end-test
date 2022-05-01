using Aliquota.Forms.Shared;

namespace Aliquota.Forms.Modules.Aplicacoes
{
    public class AplicacaoToolBoxConfig : IConfigurationToolBox
    {
        public string TipoRegistro { get { return "Aplicação"; } }

        public string ToolTipAdd { get { return "Aplicar"; } }

        public string ToolTipResgatar { get { return "Resgatar"; } }
    }
}