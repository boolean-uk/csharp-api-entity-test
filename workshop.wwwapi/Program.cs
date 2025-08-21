using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"))
    .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
    options.LogTo(message => Debug.WriteLine(message));
    options.EnableSensitiveDataLogging();

});

builder.Services.AddScoped<IRepository,Repository>();
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
app.ConfigurePrescriptionEndpoint();

app.Run();

public partial class Program { } // needed for testing - please ignore