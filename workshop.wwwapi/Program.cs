using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Models.DoctorModels;
using workshop.wwwapi.Models.PatientModels;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Repository.ExtensionRepository;
using workshop.wwwapi.Repository.GenericRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IRepository<Doctor>, DoctorRepo>();
builder.Services.AddScoped<IRepository<Patient>, PatientRepo>();
builder.Services.AddScoped<IRepository<Appointment>, AppointmentRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureSurgeryEndpoint();
app.Run();

public partial class Program { } // needed for testing - please ignore