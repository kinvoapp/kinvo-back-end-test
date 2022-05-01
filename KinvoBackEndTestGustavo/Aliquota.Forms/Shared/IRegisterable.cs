using System.Windows.Forms;

namespace Aliquota.Forms.Shared
{
    public interface IRegisterable
    {
        void AddNovoRegistro();
        void ResgatarRegistro();
        void FiltrarRegistros();
        UserControl ObterTabela();
    }
}
