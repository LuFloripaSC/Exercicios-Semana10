using ExercicioS10.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Server=LUCIANONOTE\\SQLEXPRESS;Database=LocacaoContext;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<LocacaoContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddDbContext<LocacaoContext>();

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
