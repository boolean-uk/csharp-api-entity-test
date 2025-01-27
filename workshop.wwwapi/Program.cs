using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    // NOTE: Swagger doesn't like my DTO namespaces, schema ID collides...
    // Setting custom schema Ids solves that...
    o.CustomSchemaIds(
        type => type.FullName
        );
});
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<IRepository<Doctor>,Repository<Doctor>>();
builder.Services.AddScoped<IRepository<Patient>,Repository<Patient>>();
builder.Services.AddScoped<IRepository<Appointment>,Repository<Appointment>>();
builder.Services.AddScoped<IRepository<Prescription>,Repository<Prescription>>();
builder.Services.AddScoped<IRepository<Medicine>,Repository<Medicine>>();
builder.Services.AddScoped<IRepository<MedicinesInPrescription>,Repository<MedicinesInPrescription>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();
app.ConfigurePatientEndpoint();
app.ConfigureDoctorEndpoint();
app.ConfigureAppointmentEndpoint();
app.ConfigurePrescriptionEndpoint();
app.Run();

public partial class Program { } // needed for testing - please ignore