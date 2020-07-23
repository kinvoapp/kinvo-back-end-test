using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.CrossCuting
{
    public enum TipoCliente
    {
        [Description("Condição Normal")]
        Comum,
        [Description("Condição Especial")]
        Especial,
        [Description("Funcionário")]
        Funcionario
    }
}
