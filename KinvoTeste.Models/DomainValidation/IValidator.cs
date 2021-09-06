namespace DomainValidation
{
    public interface IValidator<in TEntity>
    {
        ValidationResult Validate(TEntity entity);
    }
}
