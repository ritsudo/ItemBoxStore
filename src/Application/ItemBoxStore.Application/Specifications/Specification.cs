using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Specifications
{
    public abstract class Specification<T>
    {
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpession().Compile();
            return predicate(entity);
        }

        public abstract Expression<Func<T, bool>> ToExpession();

    }
}
