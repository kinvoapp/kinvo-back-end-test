using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.Models
{
    public class ValidaDataCadastro : ValidationAttribute
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
