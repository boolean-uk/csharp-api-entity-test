using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("patients");

            surgeryGroup.MapGet("/", GetPatients);
            surgeryGroup.MapGet("/{id}", GetPatient);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository<Patient> repository)
        {
            var patients = await repository.GetWithThenIncludes(
                q => q.Include(p => p.Appointments).ThenInclude(a => a.Doctor)
            );


            return TypedResults.Ok(patients.Select(p =>  
            new PatientDto() { 
                FullName = p.FullName,
                Appointments = p.Appointments.Select(a => 
                new PatientAppointmentDto()
                {
                    DoctorName = a.Doctor.FullName,
                    Date = a.Booking
                }).ToList()
            }));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatient(IRepository<Patient> repository, int id)
        {
            var patient = await repository.GetByIdWithThenIncludes(id,
                q => q.Include(p => p.Appointments).ThenInclude(a => a.Doctor)
            );

            if (patient == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new PatientDto() { FullName = patient.FullName, Appointments = 
                patient.Appointments.Select(a => new PatientAppointmentDto()
                {
                    DoctorName = a.Doctor.FullName,
                    Date = a.Booking
                }).ToList()
            });
        }
    }
}
