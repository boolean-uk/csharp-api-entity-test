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
            surgeryGroup.MapGet("/patients", GetPatientById);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            GetPatientsResponse response = new GetPatientsResponse();
            var results = await repository.GetPatients();

            foreach (Patient p in results)
            {
                PatientDTO patientDTO = new PatientDTO()
                {
                    Id = p.Id,
                    FullName = p.FullName
            
                };
              
                response.Patients.Add(patientDTO);
            }
            return TypedResults.Ok(response.Patients);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {

            var response = await repository.GetPatient(id);
            PatientDTO patientDTO = new PatientDTO()
            {
                Id = id,
                FullName = response.FullName
            };

            return TypedResults.Ok(patientDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetDoctors());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
    }
}
