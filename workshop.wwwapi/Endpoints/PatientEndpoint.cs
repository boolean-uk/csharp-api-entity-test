using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModels;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var patients = app.MapGroup("patients");

            patients.MapGet("/", GetPatients);
            patients.MapGet("/{id}", GetPatientById);
            patients.MapPost("/", CreatePatient);

        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            PatientResponseDTO response = new PatientResponseDTO();

            var patients = await repository.GetPatients();

            if (patients == null)
            {
                return TypedResults.NotFound();
            }

            foreach (Patient p in patients)
            {
                PatientDTOwithoutAppointment patientDTO = new PatientDTOwithoutAppointment() { Id = p.Id, FullName = p.FullName };

                response.Patients.Add(patientDTO);

            }
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientById(id);

            if (patient == null)
            {
                return TypedResults.NotFound();
            }

            PatientDTOwithoutAppointment patientDto = new PatientDTOwithoutAppointment() { Id = patient.Id, FullName = patient.FullName };

            return TypedResults.Ok(patientDto);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> CreatePatient(IRepository repository, PatientPostModel model)
        {
            try
            {
                var addedpatient = await repository.CreatePatient(new Patient() { FullName = model.FullName });

                PatientDTOwithoutAppointment patientDTO = new PatientDTOwithoutAppointment() { Id = addedpatient.Id, FullName = addedpatient.FullName };

                return TypedResults.Ok(patientDTO);

            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);

            }





        }
    }
}
