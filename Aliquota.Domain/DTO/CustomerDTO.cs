using Aliquota.Domain.Entities.Commercial;
using Aliquota.Domain.Entities.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.DTO
{
    public class CustomerDTO
    {
        public int IdCustomer { get; set; }
        public string NmCustomer { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string DtRegister { get; set; }
    }

    }
