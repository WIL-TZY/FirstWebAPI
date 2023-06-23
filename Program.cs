using FirstWebAPI.Data;
using FirstWebAPI.Repository;
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


// Debug only 
/*
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
string connectionString = configuration.GetConnectionString("Default");
Console.WriteLine("Connection String: " + connectionString);
string envVariableValue = Environment.GetEnvironmentVariable("PGADM_PASSWORD");
Console.WriteLine(envVariableValue);
*/

// Program.cs is the container (or Dependency Injector) and next line does the injection
// So whenever an instance of IUserRepository is required, the dependency injection container 
// will provide an instance of UserRepository.
// Note: The User Controller also needs to perform the injection.
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
