using Aliquota.Domain.Entities.FinancialModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aliquota.Domain.Entities.Financial
{
    public class MovementRescue : MovementBase
    {

        public DateTime DtRescue { get; set; }

        public DateTime DtRegister { get; set; }


        void MakeRescue()
        { 
        
        }
    }
}
