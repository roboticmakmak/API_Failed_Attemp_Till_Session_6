using cosmo.core2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace cosmo.core2.spesification
{
    public interface ISpecifications<T> where T : BaseEntity
    {
        //_dbContext.Products .where (p=>p.id==id).include(P=> P.ProductBrand).Include(p=>p.productType)
        //where (p=>p.id==id)
        public Expression<Func<T ,bool>> Criteria { get; set; }
        //(P=> P.ProductBrand)Include(p=>p.productType) list
        public  List<Expression<Func<T ,object>>> Includes { get;set; }


    }
}
