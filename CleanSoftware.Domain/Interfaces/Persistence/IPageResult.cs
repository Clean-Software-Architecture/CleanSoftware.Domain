namespace CleanSoftware.Domain.Interfaces.Persistence
{
    public interface IPageResult<T> where T : class
    {
        IReadOnlyCollection<T> Data { get; }

        long TotalCount { get; }
    }
}