using Onion.ApiConsume.Application;
using Onion.ApiConsume.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region ServiceRegistration

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
