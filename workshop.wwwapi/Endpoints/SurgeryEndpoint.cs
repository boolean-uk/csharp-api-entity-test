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
            var patientGroup = app.MapGroup("patients");

            patientGroup.MapGet("/", GetPatients);
            patientGroup.MapGet("/{id}", GetPatientsById);
            patientGroup.MapPost("/create", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var data = await repository.GetPatients();
            var patients = from patient in data
                           select new PatientDTO()
                           {
                               Id = patient.Id,
                               Name = $"{patient.FirstName} {patient.LastName}",
                           };
            
            return TypedResults.Ok(patients);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientsById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);
            if(patient == null)
            {
                return TypedResults.NotFound();
            }
            var result = new PatientDTO()
            {
                Id = patient.Id,
                Name = $"{patient.FirstName} {patient.LastName}",
            };
            
            return TypedResults.Ok(result);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(IRepository repository, PostPatient model)
        {
            if(model.FirstName.Length == 0 || model.LastName.Length == 0)
            {
                return TypedResults.BadRequest();
            }
            var patient = await repository.CreatePatient(model);
            var result = new PatientDTO()
            {
                Id = patient.Id,
                Name = $"{patient.FirstName} {patient.LastName}",
            };

            return TypedResults.Ok(result);
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
