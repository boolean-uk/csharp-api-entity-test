using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(

    opt => {
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"));
   }
    );
builder.Services.AddScoped<IRepository,Repository>();
builder.Services.AddScoped<IMedPrescriptionRepository, MedPrescriptionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();
app.ConfigurePatientEndpoint();
//app.ApplyProjectMigrations();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyProjectMigrations();
app.Run();

public partial class Program { } // needed for testing - please ignore