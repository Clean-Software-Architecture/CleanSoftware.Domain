namespace CleanSoftware.Domain.Models.Persistence
{
    public class CursorPagination : Pagination
    {
        public CursorPagination(string cursor, int take)
            : base(take)
        {
            Cursor = cursor;
        }

        public string Cursor { get; private set; }
    }
}
