using System.Collections.Generic;

namespace DomainValidation
{
    public abstract class Validator<TEntity> : IValidator<TEntity> where TEntity : class
    {
        private Dictionary<string, IRule<TEntity>> _rules;

        protected Validator() {
        }

        public virtual ValidationResult Validate(TEntity entity)
        {
            var result = new ValidationResult();

            if (_rules != null)
            {
                foreach (var item in _rules)
                {
                    if (!item.Value.Validate(entity))
                    {
                        result.Add(new ValidationError(item.Value.ErrorMessage));
                        throw new System.Exception(item.Value.ErrorMessage);
                    }
                }
            }

            return result;
        }

        protected virtual void Add(string name, IRule<TEntity> rule)
        {
            if (_rules == null)
                _rules = new Dictionary<string, IRule<TEntity>>();

            _rules.Add(name, rule);
        }

        protected IRule<TEntity> GetRule(string name) {
            if (_rules.ContainsKey(name))
                return _rules[name];
            return null;
        }

        protected virtual void Remove(string name)
        {
            if (_rules.ContainsKey(name))
                _rules.Remove(name);
        }
    }
}
