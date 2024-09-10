using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
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
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", AddPatient);
            surgeryGroup.MapPost("/doctors", AddDoctor);
            surgeryGroup.MapPost("/appointments", AddAppointment);
            surgeryGroup.MapGet("/appointments", GetAppointments);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            return TypedResults.Ok(DTOConverter.DTOAppointmentListConverter(appointments));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            return TypedResults.Ok(DTOConverter.DTOPeopleListConverter(patients));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            return TypedResults.Ok(DTOConverter.DTOPeopleListConverter(doctors));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            return TypedResults.Ok(DTOConverter.DTOAppointmentListConverter(appointments));
        }
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);
            return TypedResults.Ok(DTOConverter.DTOAppointmentListConverter(appointments));         
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);
            return TypedResults.Ok(DTOConverter.DTOPersonConverter(patient));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorById(id);
            return TypedResults.Ok(DTOConverter.DTOPersonConverter(doctor));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddPatient(IRepository repository, int id, string name)
        {
            var patient = await repository.AddPatient(id, name);
            return TypedResults.Ok(DTOConverter.DTOPersonConverter(patient));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddDoctor(IRepository repository, int id, string name)
        {
            var doctor = await repository.AddDoctor(id, name);
            return TypedResults.Ok(DTOConverter.DTOPersonConverter(doctor));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddAppointment(IRepository repository, int doctorId, int patientId, DateTime dateTime)
        {
            var appointment = await repository.AddAppointment(doctorId, patientId, dateTime);
            return TypedResults.Ok(DTOConverter.DTOAppointmentConverter(appointment));
        }
    }
}
