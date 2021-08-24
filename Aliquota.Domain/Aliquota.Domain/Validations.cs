using System;
using System.ComponentModel.DataAnnotations;

namespace Aliquota.Domain
{
    public class DateTimeSmallerThanNow : ValidationAttribute
    {      
        public override bool IsValid(object value)
        {
            DateTime data = (DateTime)value;
            if (data > DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
