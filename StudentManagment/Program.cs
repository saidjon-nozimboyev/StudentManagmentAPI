using Application.Common;
using Application.Interfaces;
using Application.Services;
using Application.Validators;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// dbConext
builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));
builder.Services.AddControllers();

// Mapper
var configuration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AutoMapperProfile>();
});
builder.Services.AddSingleton(configuration.CreateMapper());


// Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IStudentInterface, StudentRepository>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddScoped<IValidator<Student>, StudentValidator>();

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
