using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Aliquota.Domain.Business.Validation
{
    public abstract class Validator<T> : IValidation<T> where T : class
    {
        public extern Validator();
        public ValidationResult Result { get; set; }
        public extern IEnumerable<IValidationRule> GetRules(ValidationEnum operation);
        public extern IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression);
        public extern void RuleSet(ValidationEnum operation, Action action);
        public extern ValidationResult Validate(T instance, ValidationEnum operation, IValidatorSelector selector = null);
    }
}
