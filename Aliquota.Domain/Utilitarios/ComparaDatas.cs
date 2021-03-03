using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aliquota.Domain.Utilitarios
{
  public class DateGreaterThan : ValidationAttribute
  {
    private string _startDatePropertyName;
    public DateGreaterThan(string startDatePropertyName)
    {
      _startDatePropertyName = startDatePropertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var propertyInfo = validationContext.ObjectType.GetProperty(_startDatePropertyName);

      if (propertyInfo == null)
      {
        return new ValidationResult(string.Format("Propriedade desconhecida {0}", _startDatePropertyName));
      }

      var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);

      if ((DateTime)value > (DateTime)propertyValue)
      {
        return ValidationResult.Success;
      }
      else
      {
        var startDateDisplayName = propertyInfo
            .GetCustomAttributes(typeof(DisplayAttribute), true)
            .Cast<DisplayAttribute>()
            .Single()
            .Name;

        return new ValidationResult(validationContext.DisplayName + " deve ser posterior a " + startDateDisplayName + ".");
      }
    }
  }
}
