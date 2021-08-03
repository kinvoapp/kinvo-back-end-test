using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliquota.Application.Attributes
{
    class IsDateAfterAttribute : ValidationAttribute
    {
        private string _otherProperty;
        private string _message;

        public IsDateAfterAttribute(string otherProperty, string message)
        {
            _otherProperty = otherProperty;
            _message = message;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty(_otherProperty);
            if (otherProperty == null)
            {
                return new ValidationResult(string.Format("Propriedade não encontrada {0}", _otherProperty));
            }

            var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance, null);

            if (value is DateTime currentValue && otherPropertyValue is DateTime otherPropertyDateTime)
            {
                if (currentValue >= otherPropertyDateTime)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(_message);
        }
    }
}
