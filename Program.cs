using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using prueba_tecnica_api.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// var dbConnectionString = builder.Configuration.GetConnectionString("AppDb");
// builder.Services.AddDbContext<PruebaTecnicaDbContext>(x => x.UseMySql(dbConnectionString));

var connectionString = builder.Configuration.GetConnectionString("AppDb");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));
builder.Services.AddDbContext<PruebaTecnicaDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

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

app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.Run();
