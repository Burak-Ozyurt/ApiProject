using System.Reflection;
using ApiProject.WebApi.Context;
using ApiProject.WebApi.Entities;
using ApiProject.WebApi.ValidationRules;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle

builder.Services.AddDbContext<ApiContext>();

builder.Services.AddScoped<IValidator<Product>, ProductValidator>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 
var app = builder.Build();

// Pipeline yapýlandýrmasý
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();