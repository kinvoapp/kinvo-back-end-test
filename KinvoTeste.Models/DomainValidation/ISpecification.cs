namespace DomainValidation
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
