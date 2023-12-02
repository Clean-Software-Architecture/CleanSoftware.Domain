using CleanSoftware.Domain.Interfaces.Persistence;

namespace CleanSoftware.Domain.Models.Persistence
{
    public record PageResult<T> : IPageResult<T> where T : class
    {
        public PageResult(IReadOnlyCollection<T> data, long totalCount)
        {
            Data = data;
            TotalCount = totalCount;
        }

        public IReadOnlyCollection<T> Data { get; }

        public long TotalCount { get; }
    }
}
