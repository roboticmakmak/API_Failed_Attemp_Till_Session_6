using cosmo.core2.Entities;
using cosmo.core2.spesification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cosmo.repro
{
   public static  class IspesificationEvalutor<T> where T:BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null) { 
                query=query.Where(spec.Criteria);   
            }

            query = spec.Includes.Aggregate(query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));
            return query;
        }
    }
}
