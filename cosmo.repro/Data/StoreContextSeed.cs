using cosmo.core2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace cosmo.repro.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext dbContext)
        {
            if (!dbContext.ProductBrad.Any())
            {
                var BrandsData = File.ReadAllText("../cosmo.repro/Data/DataSeed/brands.json");
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
                if (Brands?.Count > 0)
                {
                    foreach (var Brand in Brands)

                        await dbContext.Set<ProductBrand>().AddAsync(Brand);



                    await dbContext.SaveChangesAsync();
                }
            }
            //seeding Types
            if (!dbContext.ProductBrad.Any())
            {
                var TypesData = File.ReadAllText("../cosmo.repro/Data/DataSeed/types.json");
                var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                if (Types?.Count > 0)
                {
                    foreach (var Type in Types)
                    {
                        await dbContext.Set<ProductType>().AddAsync(Type);

                    }
                    await dbContext.SaveChangesAsync();
                }
            }
            //seeding product

            if(!dbContext.ProductBrad.Any())
            {
                var ProductsData = File.ReadAllText("../cosmo.repro/Data/DataSeed/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                if (Products?.Count > 0)
                {
                    foreach (var product in Products)
                    {
                        await dbContext.Set<Product>().AddAsync(product);

                    }
                    await dbContext.SaveChangesAsync();


                }
            }



        }
    }
}
