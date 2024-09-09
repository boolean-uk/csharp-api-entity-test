using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using workshop.wwwapi.DTO;
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
            surgeryGroup.MapGet("/patients{id}", GetPatientById);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var found = await repository.GetPatients();
            if (found != null)
            {
                GetPatientsResponse response = new GetPatientsResponse();
                foreach(var p in found)
                {
                    GetPatientDTO patient = new(p.FirstName, p.LastName); 
                    response.Patients.Add(patient);
                }
                return TypedResults.Ok(response);
            }
            else
            {
                return TypedResults.NotFound("No patients found");
            }
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var found = await repository.GetPatientById(id);
            if (found != null)
            {
                GetPatientDTO patient = new(found.FirstName, found.LastName);
                return TypedResults.Ok(patient);
            }            
            else
            {
                return TypedResults.NotFound("Patient not found");
            }
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
