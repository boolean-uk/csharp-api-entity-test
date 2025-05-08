using System;

namespace workshop.wwwapi.Data;

public static class DatabaseInitializer
{

    public static async Task<WebApplication> Seed(this WebApplication app)
    {
            
            using (var scope = app.Services.CreateScope())
            {

                using var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                try
                {
                    Seed s = new Seed();
                    
                    context.Database.EnsureCreated();

                    if (!context.Doctors.Any())
                    {
                        context.Doctors.AddRange(
                            s.Doctors
                        );

                    }
                    if (!context.Patients.Any())
                    {
                        context.Patients.AddRange(
                            s.Patients
                        );

                    }
                    if (!context.Appointments.Any())
                    {
                        context.Appointments.AddRange(
                            s.Appointments
                        );

                    }
                    
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            return app;
    }

}
