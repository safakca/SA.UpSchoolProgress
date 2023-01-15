using Microsoft.EntityFrameworkCore;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.DAL;
public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=UpSchoolChainOfResponsibilityDb;integrated security=True;");
    }
    public DbSet<BankProcess> BankProcesses { get; set; }
}
