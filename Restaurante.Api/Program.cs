using Microsoft.Data.SqlClient;
using Restaurante.Domain.Data;
using Restaurante.Infrastructure.Data;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
// Agregar MediatR
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(typeof(Restaurante.Application.AssemblyReference).Assembly);
});
// CORS para permitir Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Agregar conexión Dapper
builder.Services.AddScoped<IConnectionFactory, SqlConnectionFactory>();
builder.Services.AddTransient<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("Restaurante")));

// Swagger y controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAngular");
app.MapControllers();
app.Run();
