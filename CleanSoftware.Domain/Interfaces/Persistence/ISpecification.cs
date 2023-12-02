using CleanSoftware.Domain.Models.Persistence;
using System.Linq.Expressions;

namespace CleanSoftware.Domain.Interfaces.Persistence
{
    public interface ISpecification<TEntity>
        where TEntity : class
    {
        IReadOnlyCollection<Expression<Func<TEntity, bool>>> Criterias { get; }

        IReadOnlyCollection<Expression<Func<TEntity, object>>> Includes { get; }

        Order<TEntity> OrderBy { get; }

        IReadOnlyCollection<Order<TEntity>> ThenOrderBy { get; }

        OffsetPagination OffsetPagination { get; }

        CursorPagination CursorPagination { get; }

        bool IsPagingEnabled { get; }
    }
}
