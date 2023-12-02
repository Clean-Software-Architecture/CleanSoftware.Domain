namespace CleanSoftware.Domain.Models.Persistence
{
    public abstract class Pagination
    {
        protected Pagination(long take)
        {
            Take = take;
        }

        public long Take { get; private set; }
    }
}
