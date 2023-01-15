using Microsoft.EntityFrameworkCore;
using UpSchool_UOW_EntityLayer;

namespace UpSchool_UOW_DataAccessLayer.Concrete;
public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=UpSchoolUnitOfWorkDb;integrated security=True;");
    }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<ProcessDetail> ProcessDetails { get; set; }
}
