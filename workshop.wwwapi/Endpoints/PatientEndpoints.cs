using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoints
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var patients = app.MapGroup("patients");

            patients.MapGet("/", GetPatients);
            patients.MapGet("/{id}", GetPatientById);
            patients.MapPost("/", AddPatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatients(IRepository<Patient> patientRepository, IRepository<Doctor> doctorRepository)
        {
            var patients = await patientRepository.GetWithIncludes(q =>
                q.Include(p => p.Appointments)
                 .ThenInclude(a => a.Doctor));
            if (patients == null || !patients.Any()) { return TypedResults.NotFound("No patients found."); }

            var doctors = (await doctorRepository.GetAll()).ToDictionary(d => d.Id, d => d.FullName);

            var patientDtos = patients.Select(p => new PatientWithAppointmentsDto
            {
                Id = p.Id,
                FullName = p.FullName,
                Appointments = p.Appointments.Select(a => new AppointmentWithDoctorDto
                {
                    DoctorId = a.DoctorId,
                    DoctorName = doctors.TryGetValue(a.DoctorId, out var name) ? name : "",
                    Booking = a.Booking
                }).ToList()
            }).ToList();

            return TypedResults.Ok(patientDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(int id, IRepository<Patient> patientRepository, IRepository<Doctor> doctorRepository)
        {
            var patients = await patientRepository.GetWithIncludes(q =>
                q.Include(p => p.Appointments)
                 .ThenInclude(a => a.Doctor));
            var patient = patients.FirstOrDefault(p => p.Id == id);
            if (patient == null) { return TypedResults.NotFound($"Patient with ID {id} not found."); }

            var doctors = (await doctorRepository.GetAll()).ToDictionary(d => d.Id, d => d.FullName);

            var patientDto = new PatientWithAppointmentsDto
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = patient.Appointments.Select(a => new AppointmentWithDoctorDto
                {
                    DoctorId = a.DoctorId,
                    DoctorName = doctors.TryGetValue(a.DoctorId, out var name) ? name : "",
                    Booking = a.Booking
                }).ToList()
            };

            return TypedResults.Ok(patientDto);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddPatient([FromBody] PersonPostDto patientPostDto, IRepository<Patient> patientRepository, HttpRequest request)
        {
            if (patientPostDto == null || string.IsNullOrWhiteSpace(patientPostDto.FullName)) { return TypedResults.BadRequest("Invalid patient data."); }
            var newPatient = new Patient { FullName = patientPostDto.FullName };
            var addedPatient = await patientRepository.Add(newPatient);

            var patientDto = new PersonDto { Id = addedPatient.Id, FullName = addedPatient.FullName };

            var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
            var location = $"{baseUrl}/patients/{addedPatient.Id}";
            return TypedResults.Created(location, patientDto);

        }
    }
}
