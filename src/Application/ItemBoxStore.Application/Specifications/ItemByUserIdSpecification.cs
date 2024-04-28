using ItemBoxStore.Domain.Items;
using ItemBoxStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Specifications
{
    public class ItemByUserIdSpecification : Specification<Item>
    {
        private readonly Guid _userId;
        public ItemByUserIdSpecification(Guid userId)
        {
            _userId = userId;
        }

        public override Expression<Func<Item, bool>> ToExpression()
        {
            return item => item.AuthorId == _userId;
        }
    }
}
