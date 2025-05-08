using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientByID);
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorByID);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments", CreateAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            var results = new List<PatientResponseDTO>();
            foreach (var patient in patients)
            {
                results.Add(new PatientResponseDTO(patient));
            }
            return TypedResults.Ok(results);
        }

        public static async Task<IResult> GetPatientByID(IRepository repository, int id)
        {
            Patient? result = await repository.GetPatientByID(id);
            if (result is null) return Results.NotFound($"Patient {id} doesn't exist");
            return TypedResults.Ok(new PatientResponseDTO(result));
        }
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPayload payload)
        {
            if (payload.Fullname is null || payload.Fullname == "")
                return TypedResults.BadRequest("No name is provided");
            Patient result = await repository.CreatePatient(payload.Fullname);
            return TypedResults.Ok(new PatientResponseDTO(result));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var results = new List<DoctorResponseDTO>();
            foreach (var doctor in doctors)
            {
                results.Add(new DoctorResponseDTO(doctor));
            }
            return TypedResults.Ok(results);
        }
        public static async Task<IResult> GetDoctorByID(IRepository repository, int id)
        {
            Doctor? result = await repository.GetDoctorByID(id);
            if (result is null) return Results.NotFound($"Doctor {id} doesn't exist");
            return TypedResults.Ok(new DoctorResponseDTO(result));
        }
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPayload payload)
        {
            if (payload.fullName is null || payload.fullName == "")
                return TypedResults.BadRequest("No name is provided");
            Doctor result = await repository.CreateDoctor(payload.fullName);
            return TypedResults.Ok(new DoctorResponseDTO(result));
        }

        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            var results = new List<AppointmentResponseDTO>();
            foreach (var appointment in appointments)
            {
                results.Add(new AppointmentResponseDTO(appointment));
            }
            return TypedResults.Ok(results);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            var results = new List<AppointmentResponseDTO>();
            foreach (var appointment in appointments)
            {
                results.Add(new AppointmentResponseDTO(appointment));
            }
            return TypedResults.Ok(results);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);
            var results = new List<AppointmentResponseDTO>();
            foreach (var appointment in appointments)
            {
                results.Add(new AppointmentResponseDTO(appointment));
            }
            return TypedResults.Ok(results);
        }

        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPayload payload)
        {
            Patient? patient = await repository.GetPatientByID(payload.PatientId);
            Doctor? doctor = await repository.GetDoctorByID(payload.DoctorId);
            if (patient is null) return TypedResults.NotFound($"Patient {payload.PatientId} doesn't exist");
            if (doctor is null) return TypedResults.NotFound($"Doctor {payload.DoctorId} doesn't exist");
            Appointment result = await repository.CreateAppointment(payload.Booking, patient, doctor);
            return TypedResults.Ok(new AppointmentResponseDTO(result));
        }

    }
}
