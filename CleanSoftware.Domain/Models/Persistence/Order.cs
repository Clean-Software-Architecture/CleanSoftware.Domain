using System.Linq.Expressions;

namespace CleanSoftware.Domain.Models.Persistence
{
    public class Order<T>
        where T : class
    {
        public Order(OrderType type, Expression<Func<T, object>> expression)
        {
            Type = type;
            Expression = expression;
        }

        public OrderType Type { get; }

        public Expression<Func<T, object>> Expression { get; }
    }
}
