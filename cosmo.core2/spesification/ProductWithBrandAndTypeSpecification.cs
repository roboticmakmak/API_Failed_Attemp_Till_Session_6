using cosmo.core2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cosmo.core2.spesification
{
    public class ProductWithBrandAndTypeSpecification : BaseSpecifications<product>
    {
        public ProductWithBrandAndTypeSpecification(): base ()
            {
            Includes.Add(P => P.ProductType);
            Includes.Add(P => P.ProductBrand);

        }   
    }
}
