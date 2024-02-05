using Microsoft.AspNetCore.Http.HttpResults;
using workshop.wwwapi.Models.DataTransfer.Doctor;
using workshop.wwwapi.Models.DataTransfer.Patient;
using workshop.wwwapi.Models.Domain;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("patient");

            group.MapGet("/", GetAll);
            group.MapGet("/{id}", Get);
            group.MapPost("/", Create);
        }
        private static async Task<IResult> GetAll(IRepository<Patient> patientRepository)
        {
            var patients = await patientRepository.GetAll();
            List<PatientWithAppointmentsDTO> results = new List<PatientWithAppointmentsDTO>();
            foreach (var patient in patients)
            {
                results.Add(new PatientWithAppointmentsDTO(patient));
            }
            return TypedResults.Ok(results);
        }

        private static async Task<IResult> Get(IRepository<Patient> patientRepository, int id)
        {
            var patient = await patientRepository.Get(id);
            return TypedResults.Ok(new PatientWithAppointmentsDTO(patient));
        }

        private static async Task<IResult> Create(IRepository<Patient> patientRepository, PatientInsertDTO patientInput)
        {
            string fullName = $"{patientInput.Firstname} {patientInput.Surname}";
            var result = await patientRepository.Insert(new Patient() { FullName = fullName });
            return TypedResults.Created(result.ID.ToString(), new PatientDTO(result));
        }
    }
}
