using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccess.Configurations;
using Portfolio.DataAccess.Entities;

namespace Portfolio.DataAccess.Context;
public class BaseContext : IdentityDbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }
    public DbSet<About> Abouts => Set<About>();
    public DbSet<Address> Addresses => Set<Address>(); 
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Skill> Skills => Set<Skill>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AboutConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new SkillConfiguration());
    }
}
