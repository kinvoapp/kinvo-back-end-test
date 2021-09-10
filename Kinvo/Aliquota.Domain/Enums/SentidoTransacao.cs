using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aliquota.Domain.Enums
{
    public enum SentidoTransacao
    {
        [Display(Name = "Entrada")]
        Entrada,

        [Display(Name = "Saída")]
        Saida
    }
}
