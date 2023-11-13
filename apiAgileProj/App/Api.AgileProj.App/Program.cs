using Api.AgileProj.Data.Context.Contract;
using Api.AgileProj.Data.Entity;
using Api.AgileProj.Data.Repository;
using Api.AgileProj.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//Connexion à la base de données
string connectionString = configuration.GetConnectionString("BddConnection");
builder.Services.AddDbContext<IAgileProjDBContext, AgileProjDBContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

//IOC of Repository
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IActionRepo, ActionRepo>();
builder.Services.AddScoped<IProjetRepo, ProjetRepo>();
builder.Services.AddScoped<ITaskPartRepo, TaskPartRepo>();
builder.Services.AddScoped<ITaskRepo, TaskRepo>();



// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
