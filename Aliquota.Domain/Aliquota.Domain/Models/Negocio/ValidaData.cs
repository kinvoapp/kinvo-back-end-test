using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Models
{
    public class ValidaData : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            var model = (Models.CadastroInvestidor)validationContext.ObjectInstance;
            DateTime _dataResgate = Convert.ToDateTime(value);
            DateTime _datAplicacao = Convert.ToDateTime(model.DataAplicacao);

            if (_datAplicacao > _dataResgate)
            {
                return new ValidationResult
                    ("A data do Resgate não pode ser inferior a data da Aplicação");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
