using CleanSoftware.Domain.Interfaces.Persistence;
using System.Linq.Expressions;

namespace CleanSoftware.Domain.Models.Persistence
{
    public class Specification<T> : ISpecification<T>
          where T : class
    {
        private readonly List<Expression<Func<T, object>>> _includes;
        private readonly List<Expression<Func<T, bool>>> _criterias;
        private readonly List<Order<T>> _thenOrderBy;

        public Specification()
        {
            _includes = new List<Expression<Func<T, object>>>();
            _criterias = new List<Expression<Func<T, bool>>>();
            _thenOrderBy = new List<Order<T>>();
        }

        public virtual IReadOnlyCollection<Expression<Func<T, object>>> Includes => _includes;

        public virtual IReadOnlyCollection<Expression<Func<T, bool>>> Criterias => _criterias;

        public virtual Order<T> OrderBy { get; private set; }

        public virtual IReadOnlyCollection<Order<T>> ThenOrderBy => _thenOrderBy;

        public virtual CursorPagination CursorPagination { get; private set; }

        public virtual OffsetPagination OffsetPagination { get; private set; }

        public virtual bool IsPagingEnabled => CursorPagination != null || OffsetPagination != null;

        public virtual Specification<T> AddCriteria(Expression<Func<T, bool>> criteria)
        {
            _criterias.Add(criteria);

            return this;
        }

        public virtual Specification<T> AddInclude(Expression<Func<T, object>> includeExpression)
        {
            _includes.Add(includeExpression);
            return this;
        }

        public virtual Specification<T> AddPagination(CursorPagination cursorPagination)
        {
            VerifyPagingNotSet();

            ArgumentNullException.ThrowIfNull(cursorPagination);

            if (cursorPagination.Take == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cursorPagination.Take));
            }

            CursorPagination = cursorPagination;

            return this;
        }

        public virtual Specification<T> AddPagination(OffsetPagination offsetPagination)
        {
            VerifyPagingNotSet();

            ArgumentNullException.ThrowIfNull(offsetPagination);

            if (offsetPagination.Skip < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offsetPagination.Skip));
            }

            if (offsetPagination.Take == 0)
            {
                throw new ArgumentException(nameof(offsetPagination.Take));
            }

            OffsetPagination = offsetPagination;

            return this;
        }

        public virtual Specification<T> AddOrderBy(
            Expression<Func<T, object>> orderByExpression,
            OrderType orderType = OrderType.Ascending)
        {
            if (OrderBy == null)
            {
                OrderBy = new Order<T>(orderType, orderByExpression);
            }
            else
            {
                _thenOrderBy.Add(new Order<T>(orderType, orderByExpression));
            }

            return this;
        }

        private void VerifyPagingNotSet()
        {
            if (IsPagingEnabled)
            {
                throw new InvalidOperationException("Paging is already set.");
            }
        }
    }
}
