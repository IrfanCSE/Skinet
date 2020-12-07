using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecifications<T> : ISpecifications<T>
    {
        public BaseSpecifications(){}

        // for add where or any boolean case.
        public BaseSpecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria {get;}
        
        // other linq method helper. 
        public List<Expression<Func<T, object>>> Includes {get;} = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy {get; private set;}
        public Expression<Func<T, object>> OrderByDesc {get; private set;}

        public int Skip {get; private set;}

        public int Take {get; private set;}

        public bool IsPagingEnable {get; set;} = true;

        protected void AddInclude(Expression<Func<T,object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T,object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDesc(Expression<Func<T,object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }

        protected void AddPagination(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnable = true;
        }
    }
}