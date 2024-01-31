using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public class GetPatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public GetPatientDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
        }
        public static List<GetPatientDTO> FromRepository(IEnumerable<Patient> patients)
        {
            var results = new List<GetPatientDTO>();
            foreach (var patient in patients)
            {
                results.Add(new GetPatientDTO(patient));
            }
            return results;
        }
    }
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patient", GetPatient);
            surgeryGroup.MapPost("/patient", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            var patient = GetPatientDTO.FromRepository(await repository.GetPatients());
            return TypedResults.Ok(patient);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var patient = new GetPatientDTO(await repository.GetPatient(id));
            return TypedResults.Ok(patient);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, CreatePatientPayload payloadData)
        {
            //Check that payloadData has values
            if(payloadData.FullName == null)
            {
                return TypedResults.BadRequest("Patient must have a name");
            }
            //Create new patient with values
            var patient = new GetPatientDTO(await repository.CreatePatient(payloadData.FullName));
            //Return TypedResults.Created of patient
            return TypedResults.Created($"/patient{payloadData.FullName}", patient);
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
