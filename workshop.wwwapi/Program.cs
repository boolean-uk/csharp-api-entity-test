using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository, Repository>();

// InMemory db
// builder.Services.AddDbContext<DatabaseContext>(options =>
//     options.UseInMemoryDatabase("TestDb"));

// Postgres db
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));



var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();      
    app.UseSwaggerUI();  
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

    if (!db.Patients.Any())
    {
        db.Patients.Add(new Patient { FullName = "Seeded Patient" });
        db.SaveChanges();
    }
}


// app.UseHttpsRedirection();

// Configure endpoints
app.ConfigurePatientEndpoint();
app.MapControllers();

app.Run();

public partial class Program { }
