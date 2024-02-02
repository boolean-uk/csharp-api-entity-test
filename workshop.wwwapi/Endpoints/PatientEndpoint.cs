using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {


        public static void ConfigurePatientEndpoint_Notuse(this WebApplication app)
        {
            var patientGroup = app.MapGroup("surgery");

            patientGroup.MapGet("/", GetAllPatients);
            patientGroup.MapGet("/{id}", GetAPatient);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllPatients(IRepository repository) {

                //Soruce:
                var source = await repository.GetPatients();

            List<OutPatientDTO> patients = new List<OutPatientDTO>();
            patients = source.Select(p => new OutPatientDTO() {FullName = p.FullName, Id = p.Id}).ToList();
            return TypedResults.Ok(patients);
           
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAPatient(IRepository repository, int ? id)
        {
            try {
            //Soruce:
            var source = await repository.GetPatient(id);

            OutPatientDTO patients = new OutPatientDTO() { FullName = source.FullName, Id = source.Id};
            
            return TypedResults.Ok(patients);
            } 

            catch (Exception ex){ return TypedResults.NotFound(ex.Message); }

        }

    }
}
