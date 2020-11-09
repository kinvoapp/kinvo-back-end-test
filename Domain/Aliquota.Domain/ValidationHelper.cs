using System;

static class ValidationHelper
{
   public static void NotNull(object argument, string parameterName)
   {
      if (argument == null) throw new ArgumentNullException(parameterName,
                                                            "The parameter cannot be null.");
   }

   public static void NotNegative(decimal argument, string parameterName)
   {
      if (argument <= 0) throw new ArgumentException(parameterName,
                                                            "The parameter cannot be negative.");
   }
   
}