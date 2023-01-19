using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.DataAccess.Entities;

namespace Portfolio.DataAccess.Configurations;
public class AboutConfiguration : IEntityTypeConfiguration<About>
{
    public void Configure(EntityTypeBuilder<About> builder)
    {
        builder.ToTable(nameof(About));
        builder.HasKey(x => x.Id);


        About[] abouts =
        {
            new() { Id=1, Information="Create and customize easily comprehensible reports. ",Title="Data Analyst and Reporting",  Company="Liberta Sofware Inc.", Experience="26 months"},
            new() { Id=2, Information="E-Commerce Web Site Backend Developer. ",Title="Junior Sofware Developer",  Company="DvSoft", Experience="6 months"},
            new() { Id=3, Information=".net Development Course",Title=".net Intern",  Company="Upschool-Akbank", Experience="4 months"},
            new() { Id=4, Information=".net Junior Developer",Title="Junior .net Developer",  Company="Ultimate Solutions", Experience="8 months"}
        };

        builder.HasData(abouts);
    }
} 
 
