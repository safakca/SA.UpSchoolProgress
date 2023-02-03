using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.ApiConsume.Domain.Entities;

namespace Onion.ApiConsume.Persistence.Configurations;
public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable(nameof(AppUser));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.AppRole)
               .WithMany(x => x.AppUsers)
               .HasForeignKey(x => x.AppRoleId)
               .OnDelete(DeleteBehavior.NoAction);

        AppUser[] appUsers =
        {
            new() { Id=1, AppRoleId=1, UserName="admin", Password="1"},
            new() { Id=2, AppRoleId=2, UserName="member", Password="1"}
        };

        builder.HasData(appUsers);
    }
}
