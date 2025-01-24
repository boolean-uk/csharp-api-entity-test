using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<IRepository<Appointment>, Repository<Appointment>>();
builder.Services.AddScoped<IRepository<Doctor>, Repository<Doctor>>();
builder.Services.AddScoped<IRepository<Patient>, Repository<Patient>>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureClinicEndpoints();
app.Run();

public partial class Program { } // needed for testing - please ignore. Ok, ignoring.