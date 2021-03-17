using Aliquota.Domain.Entities.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Entities.Commercial
{
    public class Customer : BaseEntity
    {
        public String NmCustomer { get; set; }
        public Telephone Telephone { get; set; }
        public string Email { get; set; }


        public DateTime DtRegister { get; set; }


    }

}
