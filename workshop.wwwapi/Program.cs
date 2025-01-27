using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnectionString");
    options.UseNpgsql(connectionString);

    options.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
}); 

builder.Services.AddScoped<IRepository<Patient, int>, Repository<Patient, int>>();
builder.Services.AddScoped<IRepository<Doctor, int>, Repository<Doctor, int>>();
builder.Services.AddScoped<IRepository<Appointment, int>, Repository<Appointment, int>>();
builder.Services.AddScoped<IRepository<Medicine, int>, Repository<Medicine, int>>();
builder.Services.AddScoped<IRepository<Prescription, int>, Repository<Prescription, int>>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwagger();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.ConfigureDoctorsEndpoints();
app.ConfigureAppointmentEndpoints();
app.ConfigurePatientsEndpoints();
app.ConfigurePrescriptionsEndpoints();
app.ConfigureMedicinesEndpoints();

app.Run();

public partial class Program { } // needed for testing - please ignore