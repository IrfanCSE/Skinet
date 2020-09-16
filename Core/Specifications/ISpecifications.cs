using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecifications<T>
    {
         Expression<Func<T,Boolean>> Criteria {get;}
         List<Expression<Func<T,object>>> Includes {get;}
         Expression<Func<T,object>> OrderBy {get;}
         Expression<Func<T,object>> OrderByDesc {get;}
         int Skip {get;}
         int Take {get;}
         bool IsPagingEnable {get;}
    }
}