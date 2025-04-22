using Store.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbkaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CadenaSQL")));

// codigo para probar conexion a la base de datos
var connectionString = builder.Configuration.GetConnectionString("CadenaSQL");
Console.WriteLine($"Cadena de conexi�n: {connectionString}");

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("ERROR: No se encontr� la cadena de conexi�n 'CadenaSQL'");
}
else
{
    Console.WriteLine("Cadena de conexi�n encontrada correctamente");
}

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
