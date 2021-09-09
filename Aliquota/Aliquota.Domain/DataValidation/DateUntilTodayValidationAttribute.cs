using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain.DataValidation
{
    public class DateUntilTodayValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;

            if (date < DateTime.Today)
            {
                return true;
            }

            return false;
        }
    }
}
