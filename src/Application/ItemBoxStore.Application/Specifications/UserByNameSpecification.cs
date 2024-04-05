using ItemBoxStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Specifications
{
    public class UserByNameSpecification : Specification<User>
    {
        private readonly string _name;
        public UserByNameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<User, bool>> ToExpession()
        {
            return user => user.Login == _name;
        }
    }
}
