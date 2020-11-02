using System;
using System.Collections.Generic;
using System.Text;

namespace Income.Tax.Willian.Santos.Kinvo.Domain.Enum
{
    public enum ETimeType
    {
        LessThanOrEqualToOneYear = 365,
        GreaterThanOneYearAndLessThanOrEqualToTwoYears = 366,
        GreaterThanTwoYears = 731,
    }
}
