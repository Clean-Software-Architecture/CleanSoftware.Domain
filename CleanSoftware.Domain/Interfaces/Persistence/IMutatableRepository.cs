namespace CleanSoftware.Domain.Interfaces.Persistence
{
    public interface IMutatableRepository<TAggregate, TIdentifier> : IReadableRepository<TAggregate, TIdentifier>
        where TAggregate : class, IAggregate<TIdentifier>
        where TIdentifier : notnull
    {
        Task<TAggregate> AddAsync(TAggregate aggregate);

        Task<IReadOnlyCollection<TAggregate>> AddAsync(IReadOnlyCollection<TAggregate> aggregates);

        Task<TAggregate> UpdateAsync(TAggregate aggregate);

        Task<TAggregate> DeleteAsync(TAggregate aggregate);
    }
}