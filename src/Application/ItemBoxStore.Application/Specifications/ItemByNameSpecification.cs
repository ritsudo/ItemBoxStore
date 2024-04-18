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
    public class ItemByNameSpecification : Specification<Item>
    {
        private readonly string _name;
        public ItemByNameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<Item, bool>> ToExpression()
        {
            return item => item.Name == _name;
        }
    }
}
