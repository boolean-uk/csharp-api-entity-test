using workshop.wwwapi.Models.Responses;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoints
    {
        public static void ConfigurePatientEndpoints(this WebApplication app)
        {
            var patients = app.MapGroup("/patients");

            patients.MapGet("/", GetPatients);
            patients.MapGet("/{id}", GetSinglePatient);
            patients.MapPost("/", CreatePatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IPatientRepository repository)
        {
            var patients = await repository.GetAllAsync();

            var patientDTOs = patients.Select(p => new PatientDTO
            {
                Id = p.Id,
                FullName = p.FullName,
                Appointments = p.Appointments.Select(a => new AppointmentDTO
                {
                    PatientId = a.PatientId,
                    PatientName = p.FullName,
                    DoctorId = a.DoctorId,
                    DoctorName = a.Doctor?.FullName ?? "Unknown",
                    Booking = a.Booking
                }).ToList() ?? new List<AppointmentDTO>()
            }).ToList();

            return TypedResults.Ok(patientDTOs);  // Let ASP.NET Core handle the serialization automatically
        }




        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetSinglePatient(IPatientRepository repository, int id)
        {
            var patient = await repository.GetPatientWithAppointments(id);
            if (patient == null) return TypedResults.NotFound();

            var patientDTO = new PatientDTO
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = patient.Appointments.Select(a => new AppointmentDTO
                {
                    PatientId = a.PatientId,
                    PatientName = patient.FullName,
                    DoctorId = a.DoctorId,
                    DoctorName = a.Doctor.FullName,
                    Booking = a.Booking
                }).ToList()
            };

            return TypedResults.Ok(patientDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IPatientRepository repository, Patient patient)
        {
            var createdPatient = await repository.AddAsync(patient);
            return TypedResults.Created($"/api/patients/{createdPatient.Id}", createdPatient);
        }
    }
}
