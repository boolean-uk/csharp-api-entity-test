using Microsoft.AspNetCore.Mvc;
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

            // Patient endpoints
            surgeryGroup.MapGet("/patients" , GetPatients);
            surgeryGroup.MapGet("/patients/{id}" , GetPatientById);
            surgeryGroup.MapPost("/patients" , CreatePatient);

            // Doctor endpoints
            surgeryGroup.MapGet("/doctors" , GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}" , GetDoctorById);
            surgeryGroup.MapPost("/doctors" , CreateDoctor);

            // Appointment endpoints
            surgeryGroup.MapGet("/appointments" , GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}" , GetAppointmentById);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}" , GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}" , GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments" , CreateAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository , int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository , int id)
        {
            var patientDto = await repository.GetPatientById(id);
            if(patientDto == null)
            {
                return Results.NotFound($"Patient with ID {id} not found.");
            }
            return Results.Ok(patientDto);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository , PatientDto patientDto)
        {
            var patient = await repository.CreatePatient(patientDto);
            return Results.Created($"/patients/{patient.Id}" , patient);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository , int id)
        {
            var doctor = await repository.GetDoctorById(id);
            if(doctor == null)
            {
                return Results.NotFound($"Doctor with ID {id} not found.");
            }
            return Results.Ok(doctor);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository repository , DoctorDto doctorDto)
        {
            var doctor = await repository.CreateDoctor(doctorDto);
            return Results.Created($"/doctors/{doctor.Id}" , doctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetAppointments());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById(IRepository repository , int patientId , int doctorId)
        {
            var appointment = await repository.GetAppointmentById(patientId , doctorId);
            if(appointment == null)
            {
                return Results.NotFound($"Appointment with Patient ID {patientId} and Doctor ID {doctorId} not found.");
            }
            return Results.Ok(appointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository , int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByPatientId(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateAppointment(IRepository repository , AppointmentDto appointmentDto)
        {
            var appointment = await repository.CreateAppointment(appointmentDto);
            return Results.Created($"/appointments/{appointment.Id}" , appointment);
        }
    }
}
