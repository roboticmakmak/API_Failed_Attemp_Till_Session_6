using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cosmo.core2.Entities
{
    public class product : BaseEntity
    {
   
        public string Name { get; set; }    
        public string Description { get; set; }
        public string PictureUrl { get; set; }  
        public decimal price { get; set; }

        public int ProductBrandId { get; set; } //fk
        public ProductBrand ProductBrand { get; set; }
        public  int ProductTypeId { get; set; } //fk
        public Product_Type ProductType { get; set; }
    }
}
