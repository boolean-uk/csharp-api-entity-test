using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
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
            surgeryGroup.MapGet("/patient{id}", GetPatient);
            surgeryGroup.MapPost("/CreateAPatient", CreateAPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var result = await repository.GetPatients();
            List<patientDTO> resultDTO = new List<patientDTO>();
            foreach (var patient in result)
            {
                resultDTO.Add(new patientDTO(patient));
            }
            return TypedResults.Ok(resultDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            if (id <= 0)
            {
                return TypedResults.BadRequest("id needs to be a positive number above 0");
            }
            var result = await repository.GetPatient(id);

            if (result == null)
            {
                return TypedResults.NotFound("id was not valid");
            }
            else
            {
                patientDTO resultDTO = new patientDTO(result);
                return TypedResults.Ok(resultDTO);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateAPatient(IRepository repository, PatientPostPayload patientPayload)
        {
            if (patientPayload == null)
            {
                return TypedResults.BadRequest("Not valid payload");
            }
            if (patientPayload.fullName == null || patientPayload.fullName == string.Empty)
            {
                return TypedResults.NotFound("not a valid name");
            }

            var result = await repository.CreateAPatient(patientPayload);
            var resultDTO = new patientDTO(result);

            return TypedResults.Ok(resultDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
    }
}
