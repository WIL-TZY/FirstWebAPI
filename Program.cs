using FirstWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

// Retrieve the environment variable balue
string password = Environment.GetEnvironmentVariable("PGADM_PASSWORD");

string connectionString = configuration.GetConnectionString("Default").Replace("__PGADM_PASSWORD__", password);

// Debug only //Password=${PGADM_PASSWORD}
Console.WriteLine("Connection String: " + connectionString);
string envVariableValue = Environment.GetEnvironmentVariable("PGADM_PASSWORD");
Console.WriteLine(envVariableValue);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
