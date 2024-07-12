using API.Helper;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
    

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conexion = builder.Configuration.GetConnectionString("conexion");
builder.Services.AddDbContext<Contexto>(options => options.UseMySql(conexion,ServerVersion.AutoDetect(conexion)));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Mapping));
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
