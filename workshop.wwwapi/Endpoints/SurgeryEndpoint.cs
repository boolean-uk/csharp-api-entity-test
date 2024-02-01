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
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapPost("/patients", AddPatient);
            //surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            List<GetPatientDTO> dtos = patients
                .Select(p => new GetPatientDTO()
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                })
                .ToList();
            return TypedResults.Ok(dtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            try
            {
                Patient patient = await repository.GetPatientById(id);
                GetPatientDTO dto = new()
                {
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                };
                return TypedResults.Ok(dto);
            }
            catch (ArgumentException ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        public static async Task<IResult> AddPatient(IRepository repository, AddPatientDTO dto)
        {
            try
            {
                Patient patient = await repository.AddPatient(dto);
                GetPatientDTO getDTO = new()
                {
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                };
                return TypedResults.Ok(getDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        //{
        //    return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        //}
    }
}
