using System;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data;

public static class DatabaseInitializer
{
    public async static Task<WebApplication> Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
            {

                using var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                try
                {
                    
                    context.Database.EnsureCreated();

                    PatientData PatientData = new PatientData();
                    if (!context.Patients.Any())
                    {
                        context.Patients.AddRange(PatientData.Patients);
                        
                    }

                    DoctorData doctorData = new DoctorData();
                    if (!context.Doctors.Any())
                    {
                        context.Doctors.AddRange(doctorData.Doctors);
                    }

                    AppointmentData AppointmentData = new AppointmentData();
                    if(!context.Appointments.Any())
                    {
                        context.Appointments.AddRange(AppointmentData.Appointments);        
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
