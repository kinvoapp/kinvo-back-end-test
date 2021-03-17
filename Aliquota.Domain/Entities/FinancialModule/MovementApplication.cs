using Aliquota.Domain.Entities.FinancialModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aliquota.Domain.Entities.Financial
{
    public class MovementApplication : MovementBase
    {

        public int QtLot { get; private set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; private set; }
        public DateTime DtRegister { get; private set; }


        public void MakeApplication(int QtLot, decimal Value, DateTime DtRegister)
        {
            if (QtLot <= 0)
                throw new Exception("Quantidade de lotes deve ser maior ou igual a zero.");
            
            if (Value <= 0)
                throw new Exception("Valor deve ser maior ou igual a zero.");

            this.QtLot = QtLot;
            this.Value = Value;
            this.DtRegister = DtRegister;

        }
    }
}
