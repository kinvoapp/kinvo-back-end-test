using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Aliquota.Domain.Business.Validation
{
    public interface IValidation<T> where T : class
    {
        ValidationResult Result { get; set; }
        IEnumerable<IValidationRule> GetRules(ValidationEnum operation);
        IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression);
        void RuleSet(ValidationEnum operation, Action action);
        ValidationResult Validate(T instance, ValidationEnum operation, IValidatorSelector selector = null);
    }
}
