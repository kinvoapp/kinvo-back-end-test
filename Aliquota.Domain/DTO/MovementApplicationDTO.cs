using Aliquota.Domain.Entities.Commercial;
using Aliquota.Domain.Entities.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.DTO
{
    public class MovementApplicationDTO
    {

        public int Id { get; set; }
        public int QtLot { get; set; }
        public decimal Value { get; set; }
        public string DtRegister { get; set; }

        public int TaxId { get; set; }

    }

}
