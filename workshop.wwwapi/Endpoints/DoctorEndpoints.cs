using workshop.wwwapi.Models.Responses;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoints
    {
        public static void ConfigureDoctorEndpoints(this WebApplication app)
        {
            var doctors = app.MapGroup("/doctors");

            doctors.MapGet("/", GetDoctors);
            doctors.MapGet("/{id}", GetSingleDoctor);
            doctors.MapPost("/", CreateDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IDoctorRepository repository)
        {
            var doctors = await repository.GetAllAsync();

            var doctorDTOs = doctors.Select(d => new DoctorDTO
            {
                Id = d.Id,
                FullName = d.FullName,
                Appointments = d.Appointments.Select(a => new AppointmentDTO
                {
                    PatientId = a.PatientId,
                    PatientName = a.Patient != null ? a.Patient.FullName : "Unknown", 
                    DoctorId = a.DoctorId,
                    DoctorName = d.FullName,
                    Booking = a.Booking
                }).ToList()
            }).ToList();

            return TypedResults.Ok(doctorDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetSingleDoctor(IDoctorRepository repository, int id)
        {
            var doctor = await repository.GetDoctorWithAppointments(id);
            if (doctor == null) return TypedResults.NotFound();

            var doctorDTO = new DoctorDTO
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Appointments = doctor.Appointments.Select(a => new AppointmentDTO
                {
                    PatientId = a.PatientId,
                    PatientName = a.Patient.FullName,
                    DoctorId = a.DoctorId,
                    DoctorName = doctor.FullName,
                    Booking = a.Booking
                }).ToList()
            };

            return TypedResults.Ok(doctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IDoctorRepository repository, Doctor doctor)
        {
            var createdDoctor = await repository.AddAsync(doctor);
            return TypedResults.Created($"/doctors/{createdDoctor.Id}", createdDoctor);
        }
    }
}
