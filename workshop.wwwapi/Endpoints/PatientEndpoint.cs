using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("patients");

            surgeryGroup.MapGet("/", GetPatients);
            surgeryGroup.MapGet("/{id}", GetPatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            IEnumerable<Patient> patients = await repository.GetPatients();
            List<PatientDto> patientDtos = patients.Select(patients => patients.ToDto()).ToList();
            return TypedResults.Ok(patientDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatient(id);
            
            if (patient == null) return TypedResults.NotFound();

            return TypedResults.Ok(patient.ToDto()); ;
        }
    }
}
