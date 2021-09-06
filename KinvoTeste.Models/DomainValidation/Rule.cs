using System;

namespace DomainValidation
{
    public class Rule<TEntity> : IRule<TEntity>
    {
        private ISpecification<TEntity> _spec;

        public Rule(ISpecification<TEntity> spec, string errorMessage)
        {
            _spec = spec;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; }

        public bool Validate(TEntity entity)
        {
            return _spec.IsSatisfiedBy(entity);
        }
    }
}
