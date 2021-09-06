namespace DomainValidation
{
    public interface IRule<in TEntity>
    {
        string ErrorMessage { get; }

        bool Validate(TEntity entity);
    }
}
