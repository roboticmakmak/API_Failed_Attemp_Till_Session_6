using cosmo.core2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace cosmo.core2.spesification
{

    public class BaseSpecifications<T> : ISpecifications<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }=  new List<Expression<Func<T, object>>>();

        // Constructor without parameters
        public BaseSpecifications()
        {
           // Includes = new List<Expression<Func<T, object>>>();
        }

        // Constructor with a parameter for Criteria
        public BaseSpecifications(Expression<Func<T, bool>> criteriaExpretions)
        {
        
            Criteria = criteriaExpretions;
            
            //Includes = new List<Expression<Func<T, object>>>();
        }
    }



}
