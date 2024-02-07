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
            var surgeryGroup = app.MapGroup("surgery/");

            //patients
            surgeryGroup.MapGet("patients", GetPatients);
            surgeryGroup.MapGet("patients/{id}", GetPatientById);
            surgeryGroup.MapPost("patients", CreatePatient);
            //doctors
            surgeryGroup.MapGet("doctors", GetDoctors);
            surgeryGroup.MapGet("doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("doctors", CreateDoctor);
            //appointments
            surgeryGroup.MapGet("appointments", GetAppointments);
            surgeryGroup.MapGet("appointments/{patientId}/{doctorId}", GetAppointment);
            surgeryGroup.MapGet("appointments/doctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("appointments/patient/{id}", GetAppointmentsByPatient);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(await repository.GetPatients());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            if (await repository.PatientIdExists(id))
            {
                return TypedResults.Ok(await repository.GetPatientById(id));
            }
            return TypedResults.NotFound($"Couldn't find patient of id: {id}");
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientCreate patient)
        {
            return TypedResults.Created("New patient created", await repository.CreatePatient(patient));
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetDoctorById(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorCreate doctor)
        {
            return TypedResults.Created("New doctor created", await repository.CreateDoctor(doctor));
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetAppointments());
        }

        public static async Task<IResult> GetAppointment(IRepository repository, int patientId, int doctorId)
        {
            return TypedResults.Ok(await repository.GetAppointmentById(patientId, doctorId));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }

        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByPatient(id));
        }
    }
}
