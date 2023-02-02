using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onion.ApiConsume.Domain.Entities;

namespace Onion.ApiConsume.Persistence.Configurations;
public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasOne(x => x.AppRole)
               .WithMany(x => x.AppUsers)
               .HasForeignKey(x => x.AppRoleId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
