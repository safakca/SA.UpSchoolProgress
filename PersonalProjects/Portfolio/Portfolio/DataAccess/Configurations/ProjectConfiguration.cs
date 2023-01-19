using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.DataAccess.Entities;

namespace Portfolio.DataAccess.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable(nameof(Project));
        builder.HasKey(x => x.Id);


        Project[] projects =
        {
            new() { Id=1, Name="OOP Examples", LinkAddress="https://github.com/safakca/SA.OopExamples"},
            new() { Id=2, Name="Base Web Api In .net 5", LinkAddress="https://github.com/safakca/SA.BaseWebApiNetCore5"},
            new() { Id=3, Name="CQRS In .net 5", LinkAddress="https://github.com/safakca/SA.BaseCQRS"},
            new() { Id=4, Name="CQRS nTier In .net 5", LinkAddress="https://github.com/safakca/BaseAPI/tree/master/CQRSapi_2"},
            new() { Id=5, Name="File Upload In .net 6", LinkAddress="https://github.com/safakca/SA.BaseFileUpload"},
            new() { Id=6, Name="Case Example", LinkAddress="https://github.com/safakca/SA.KUSYS-DEMO"},
            new() { Id=7, Name="Chat App In .net 7 with SignalR", LinkAddress="https://github.com/safakca/SA.BaseSignalRChatApp"},
            new() { Id=8, Name="Api Consume In .net 6 with MVC", LinkAddress="https://github.com/safakca/SA.ApiConsume"},
            new() { Id=9, Name="Base Identity In .net 6", LinkAddress="https://github.com/safakca/SA.BaseIdentity"}
        };

        builder.HasData(projects);
    }
}


 
