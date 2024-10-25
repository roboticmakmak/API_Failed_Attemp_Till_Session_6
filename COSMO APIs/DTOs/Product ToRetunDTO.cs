using cosmo.core2.Entities;

namespace COSMO_APIs.DTOs
{
    public class ProductTORetunDTO

    {
        internal object ProductType;
        internal object ProductBrand;

        public class product : BaseEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string PictureUrl { get; set; }
            public decimal price { get; set; }

            public int ProductBrandId { get; set; } //fk
            public string ProductBrand { get; set; }
            public int ProductTypeId { get; set; } //fk
            public string ProductType { get; set; }
        }
    }
}
