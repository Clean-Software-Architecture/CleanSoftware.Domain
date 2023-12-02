namespace CleanSoftware.Domain.Models.Persistence
{
    public class OffsetPagination : Pagination
    {
        public OffsetPagination(long skip, long take)
            : base(take)
        {
            Skip = skip;
        }

        public long Skip { get; private set; }
    }
}
