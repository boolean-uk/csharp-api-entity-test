using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoint
    {
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var doctors = app.MapGroup("doctor");

            doctors.MapGet("/", GetDoctors);
            doctors.MapGet("/{id}", GetDoctor);
            doctors.MapPost("/{id}", CreateDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor> repository)
        {
            var doctors = await repository.GetWithThenIncludes(
                q => q.Include(d => d.Appointments).ThenInclude(a => a.Patient));
            return TypedResults.Ok(doctors.Select(d => new DoctorDto() { FullName = d.FullName,
                Appointments = d.Appointments.Select(a => new DoctorAppointmentDto()
                {
                    PatientName = a.Patient.FullName,
                    Date = a.Booking
                }).ToList()
            }));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctor(IRepository<Doctor> repository, int id)
        {
            var doctor = await repository.GetByIdWithThenIncludes(id,
                q => q.Include(d => d.Appointments).ThenInclude(a => a.Patient));
            if (doctor == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new DoctorDto() { FullName = doctor.FullName,
                Appointments = doctor.Appointments.Select(a => new DoctorAppointmentDto()
                {
                    PatientName = a.Patient.FullName,
                    Date = a.Booking
                }).ToList()
            });
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository<Doctor> repository, DoctorDto doctorDto)
        {
            var doctor = new Doctor() { FullName = doctorDto.FullName };
            await repository.Insert(doctor);
            return TypedResults.Created("somepath",new DoctorDto() { FullName = doctor.FullName });
        }
    }
}
