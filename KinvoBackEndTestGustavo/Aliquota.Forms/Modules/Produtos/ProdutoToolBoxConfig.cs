using Aliquota.Forms.Shared;

namespace Aliquota.Forms.Modules.Produtos
{
    public class ProdutoToolBoxConfig : IConfigurationToolBox
    {
        public string TipoRegistro { get { return "Produto"; } }

        public string ToolTipAdd { get { return "Criar produto"; } }

        public string ToolTipResgatar { get { return ""; } }
    }
}