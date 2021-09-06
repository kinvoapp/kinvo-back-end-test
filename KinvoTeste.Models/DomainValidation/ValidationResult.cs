using System.Collections.Generic;

namespace DomainValidation
{
    public class ValidationResult
    {
        private IEnumerable<ValidationError> _erros;
        public IEnumerable<ValidationError> Erros { get { return _erros; } }

        public ValidationResult() {
            _erros = new List<ValidationError>();
        }

        public bool IsValid { get { return ((List<ValidationError>)_erros).Count == 0; } }
        public string Message { get; set; }

        public void Add(ValidationError error) {
            ((List<ValidationError>)_erros).Add(error);
        }

        public void Add(params ValidationResult[] validationResults)
        {
            foreach (var item in validationResults)
            {
                ((List<ValidationError>)_erros).AddRange(item.Erros);
            }
        }

        public void Remove(ValidationError error)
        {
            ((List<ValidationError>)_erros).Remove(error);
        }
    }
}
