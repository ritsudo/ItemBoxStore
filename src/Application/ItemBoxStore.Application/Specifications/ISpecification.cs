using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Specifications
{
    public interface ISpecification
    {
        bool IsSatisfiedBy(object candidate);
        ISpecification And(ISpecification other);
        ISpecification Or(ISpecification other);
        ISpecification Not();
    }
}
