namespace CleanSoftware.Domain.Interfaces.Persistence
{
    public interface IReadableRepository<TEntity, TIdentifier> : IReadableRepository<TEntity>
        where TEntity : class, IIdentifiable<TIdentifier>
        where TIdentifier : notnull
    {
    }

    public interface IReadableRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity?> GetFirstOrDefaultAsync(
            ISpecification<TEntity> specification);

        Task<IPageResult<TEntity>> GetAllAsync(
            ISpecification<TEntity> specification);

        Task<int> CountAsync(
            ISpecification<TEntity> specification);
    }
}
