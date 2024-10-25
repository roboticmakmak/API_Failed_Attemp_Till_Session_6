using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cosmo.repro.Data.configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // builder.HasOne(p => p.ProductBrand)
            // .WithMany()
            // .HasForeignKey(foreignKeyExpression: p => p.ProductBrandId);
            builder.HasOne(p => p.ProductBrand)
               .WithMany()
           .HasForeignKey(p => p.ProductBrandId);





            // builder.HasOne(P => P.ProductType)
            //  .WithMany()
            // .HasForeignKey(p => p.ProductTypeId);
            builder.HasOne(p => p.ProductType)
               .WithMany()
               .HasForeignKey(p => p.ProductTypeId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Name).IsRequired()
                .HasMaxLength(100);

            builder.Property(P=>P.Description).IsRequired() ;
            builder.Property(P=>P.PictureUrl).IsRequired() ;
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
