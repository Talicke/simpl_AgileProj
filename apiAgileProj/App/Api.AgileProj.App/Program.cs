using Api.AgileProj.Business.Services;
using Api.AgileProj.Business.Services.Contract;
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
builder.Services.AddScoped<IProjectRepo, ProjetRepo>();
builder.Services.AddScoped<ITakePartRepo, TakePartRepo>();
builder.Services.AddScoped<ITaskRepo, TaskRepo>();

//IOC of Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IActionService, ActionService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITakePartService, TakePartService>();
builder.Services.AddScoped<ITaskService, TaskService>();

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
