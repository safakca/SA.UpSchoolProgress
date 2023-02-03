using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.DataAccess.Entities;

namespace Portfolio.DataAccess.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.ToTable(nameof(Skill));
        builder.HasKey(x => x.Id);


        Skill[] skills =
        {
            new() { Id=1, Name="C#", Detail="https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/"},
            new() { Id=2, Name="Visual Studio", Detail="https://visualstudio.microsoft.com/tr/"},
            new() { Id=3, Name="Visual Studio Code", Detail="https://code.visualstudio.com/"},
            new() { Id=4, Name=".net", Detail="https://learn.microsoft.com/tr-tr/dotnet/core/introduction"},
            new() { Id=5, Name=".netCore", Detail="https://learn.microsoft.com/tr-tr/dotnet/core/introduction"},
            new() { Id=6, Name="Entity Framework", Detail="https://learn.microsoft.com/en-us/ef/ef6/get-started"},
            new() { Id=7, Name="Github", Detail="https://github.com/"},
            new() { Id=8, Name="GitLab", Detail="https://about.gitlab.com/"},
            new() { Id=9, Name="Postman", Detail="https://www.postman.com/"},
            new() { Id=10, Name="Swagger", Detail="https://swagger.io/"},
            new() { Id=11, Name="MsSQL", Detail="https://www.microsoft.com/tr-tr/sql-server/sql-server-2019"},
            new() { Id=12, Name="PosgreSQL", Detail="https://www.postgresql.org/"},
            new() { Id=13, Name="MongoDB", Detail="https://www.mongodb.com/"},
            new() { Id=14, Name="Jira", Detail="https://www.atlassian.com/software/jira"},
            new() { Id=15, Name="Trello", Detail="https://trello.com/"}

        };

        builder.HasData(skills);
    }
}


 
