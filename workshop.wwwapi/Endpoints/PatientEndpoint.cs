using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.PureModels;
using workshop.wwwapi.Models.TransferInputModels;
using workshop.wwwapi.Models.TransferModels.People;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var patients = app.MapGroup("/patients");
            // Patients
            patients.MapGet("/", GetPatients);
            patients.MapGet("/{id}", GetSpecificPatient);
            patients.MapPost("/", CreatePatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();


            IEnumerable<PatientDTO> patientsOut = patients.Select(p => new PatientDTO(p.Id, p.FullName, p.Appointments));
            Payload<IEnumerable<PatientDTO>> payload = new Payload<IEnumerable<PatientDTO>>(patientsOut);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetSpecificPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);
            if (patient == null)
            {
                return TypedResults.NotFound("No patient with the provided Id could be found.");
            }

            PatientDTO patientOut = new PatientDTO(patient.Id, patient.FullName, patient.Appointments);
            Payload<PatientDTO> payload = new Payload<PatientDTO>(patientOut);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> CreatePatient(IRepository repository, PatientInputDTO patientPost)
        {
            Patient postedPatient = await repository.PostPatient(new Patient() { FullName = patientPost.fullName });

            Payload<Patient> payload = new Payload<Patient>(postedPatient);
            return TypedResults.Created($"/{postedPatient.Id}", payload);

        }
    }
}
