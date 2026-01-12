using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoints
    {
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var doctors = app.MapGroup("doctors");

            doctors.MapGet("/", GetDoctors);
            doctors.MapGet("/{id}", GetDoctorById);
            doctors.MapPost("/", AddDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor> doctorRepository, IRepository<Patient> patientRepository)
        {
            var doctors = await doctorRepository.GetWithIncludes(q =>
                q.Include(d => d.Appointments)
                 .ThenInclude(a => a.Patient));
            if (doctors == null || !doctors.Any()) { return TypedResults.NotFound("No doctors found."); }

            var patients = (await patientRepository.GetAll()).ToDictionary(p => p.Id, p => p.FullName);
            var doctorDtos = doctors.Select(d => new DoctorWithAppointmentsDto
            {
                Id = d.Id,
                FullName = d.FullName,
                Appointments = d.Appointments.Select(a => new AppointmentWithPatientDto
                {
                    PatientId = a.PatientId,
                    PatientName = patients.TryGetValue(a.PatientId, out var name) ? name : "",
                    Booking = a.Booking
                }).ToList()
            }).ToList();

            return TypedResults.Ok(doctorDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(int id, IRepository<Doctor> doctorRepository, IRepository<Patient> patientRepository)
        {
            var doctors = await doctorRepository.GetWithIncludes(q =>
                q.Include(d => d.Appointments)
                 .ThenInclude(a => a.Patient));
            var doctor = doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null) { return TypedResults.NotFound($"Doctor with ID {id} not found."); }

            var patients = (await patientRepository.GetAll()).ToDictionary(p => p.Id, p => p.FullName);
            var doctorDto = new DoctorWithAppointmentsDto
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Appointments = doctor.Appointments.Select(a => new AppointmentWithPatientDto
                {
                    PatientId = a.PatientId,
                    PatientName = patients.TryGetValue(a.PatientId, out var name) ? name : "",
                    Booking = a.Booking
                }).ToList()
            };

            return TypedResults.Ok(doctorDto);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddDoctor([FromBody] PersonPostDto doctorPostDto, IRepository<Doctor> doctorRepository, HttpRequest request)
        {
            if (doctorPostDto == null || string.IsNullOrWhiteSpace(doctorPostDto.FullName)) { return TypedResults.BadRequest("Invalid doctor data."); }
            var newDoctor = new Doctor { FullName = doctorPostDto.FullName };
            var addedDoctor = await doctorRepository.Add(newDoctor);

            var doctorDto = new PersonDto { Id = addedDoctor.Id, FullName = addedDoctor.FullName };

            var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
            var location = $"{baseUrl}/patients/{addedDoctor.Id}";
            return TypedResults.Created(location, doctorDto);

        }
    }
}
