using System.Text.Json.Serialization;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options =>
 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<IRepository,Repository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureSurgeryEndpoint();
app.ConfigureAppointmentEndpoint();
app.ConfigureDoctorEndpoint();
app.ConfigurePatientEndpoint();
app.ConfigurePrescriptionsEndpoint();

app.Run();

public partial class Program { } // needed for testing - please ignore