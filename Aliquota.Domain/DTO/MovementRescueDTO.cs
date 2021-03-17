using Aliquota.Domain.Entities.Commercial;
using Aliquota.Domain.Entities.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.DTO
{
    public class MovementRescueDTO
    {
        public string DtRescue { get; set; }

        public string DtRegister { get; set; }

        public int TaxId { get; set; }

    }

}
