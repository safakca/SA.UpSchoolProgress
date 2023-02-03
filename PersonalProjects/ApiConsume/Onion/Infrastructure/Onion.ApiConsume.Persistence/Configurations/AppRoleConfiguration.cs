using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.ApiConsume.Domain.Entities;

namespace Onion.ApiConsume.Persistence.Configurations;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.ToTable(nameof(AppRole));
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.AppUsers);

        AppRole[] appRoles =
        {
            new() { Id=1, Defination="admin"},
            new() { Id=2, Defination="member"}
        };

        builder.HasData(appRoles);
    }
}