using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.ApiConsume.Domain.Entities;

namespace Onion.ApiConsume.Persistence.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Category)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.CategoryId);


        Product[] products =
        {
            new() {Id=1, CategoryId=1, Name="Skirt", Price=500, Stock=852 },
            new() {Id=2, CategoryId=1, Name="Jean", Price=650, Stock=1000},
            new() {Id=3, CategoryId=2, Name="MacbookPro", Price=46500, Stock=200},
            new() {Id=4, CategoryId=2, Name="IMac", Price=32650, Stock=150},
        };

        builder.HasData(products);
    }
}
