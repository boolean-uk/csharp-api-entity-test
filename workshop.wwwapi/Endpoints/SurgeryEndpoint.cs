using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Models;
using SurgeryEndpoints.DTOs;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetAPatient);
            surgeryGroup.MapPost("/patients/{id}", CreateAPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            return TypedResults.Ok(await repository.GetPatients());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IResult))]
        private static async Task<IResult> GetAPatient(int patientid, IRepository repository)
        {
            var patient = await repository.GetPatient(patientid);
            if (patient == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(patient);
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IResult))]
        public static async Task<IResult> CreateAPatient(Patient patient, IRepository repository)
        {
            var newPatient = await repository.CreatePatient(patient);
            if (patient == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Created();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IResult))]
        private static async Task<IResult> GetADoctor(int doctorid, IRepository repository)
        {
            var doctor = await repository.GetDoctor(doctorid);
            if (doctor == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(doctor);
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(IResult))]
        public static async Task<IResult> CreateADoctor(Doctor doctor, IRepository repository)
        {
            var newDoctor = await repository.CreateDoctor(doctor);
            if (doctor == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Created();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
    }
}
