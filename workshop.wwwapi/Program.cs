using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Scalar.AspNetCore;
using System.Diagnostics;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DatabaseContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"));
    options.LogTo(message => Debug.WriteLine(message));

});

builder.Services.AddScoped<IRepository<Patient>, Repository<Patient>>();
builder.Services.AddScoped<IRepository<Doctor>, Repository<Doctor>>();
builder.Services.AddScoped<IRepository<Appointment>, Repository<Appointment>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.ConfigurePatientEndpoint();
app.ConfigureDoctorEndpoint();
app.ConfigureAppointmentEndpoint();
app.Run();

public partial class Program { } // needed for testing - please ignore