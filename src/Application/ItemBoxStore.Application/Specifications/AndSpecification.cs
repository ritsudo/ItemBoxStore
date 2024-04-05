using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Specifications
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _leftSpecification;
        private readonly Specification<T> _rightSpecification;
        public AndSpecification(Specification<T> leftSpecification, Specification<T> rightSpecification)
        {
            _leftSpecification = leftSpecification;
            _rightSpecification = rightSpecification;
        } 

        public override Expression<Func<T, bool>> ToExpession()
        {
            var leftExpression = _leftSpecification.ToExpession();
            var rightExpression = _rightSpecification.ToExpession();

            var paramExpr = Expression.Parameter(typeof(T));
            var combinedExpr = Expression.AndAlso(
                Expression.Invoke(leftExpression, paramExpr),
                Expression.Invoke(rightExpression, paramExpr)
            );

            return Expression.Lambda<Func<T, bool>>(combinedExpr, paramExpr);

        }
    }
}
