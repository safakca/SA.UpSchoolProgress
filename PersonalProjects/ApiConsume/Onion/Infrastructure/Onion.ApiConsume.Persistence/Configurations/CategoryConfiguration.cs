using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.ApiConsume.Domain.Entities;

namespace Onion.ApiConsume.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category));
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Products);

        Category[] categories =
        {
            new() {Id=1, Defination="Clothes"},
            new() {Id=2, Defination="Electronic"}
        };

        builder.HasData(categories);
    }
}
