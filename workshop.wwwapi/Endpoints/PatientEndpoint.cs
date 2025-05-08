using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var patients = app.MapGroup("patients");
            patients.MapGet("/", GetPatients);
            patients.MapGet("/{id}", GetPatient);
            patients.MapPost("/", CreatePatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {

            PatientResponse patientResponse = new PatientResponse();

            var patients = await repository.GetPatients();

            foreach (Patient patient in patients)
            {
                PatientDTO patientDTO = new PatientDTO() { Id = patient.Id, FullName = patient.FullName };

                foreach (var appointment in patient.Appointments)
                {
                    patientDTO.Appointments.Add(appointment);
                }

                patientResponse.patients.Add(patientDTO);
            }

            return TypedResults.Ok(patientResponse);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatient(id);

            if (patient == null) return TypedResults.NotFound();

            PatientDTO patientDTO = new PatientDTO() { Id = patient.Id, FullName = patient.FullName };

            foreach (var appointment in patient.Appointments)
            {
                patientDTO.Appointments.Add(appointment);
            }

            return TypedResults.Ok(patientDTO);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePatient(IRepository repository, Patient patient)
        {
            try
            {
                var addPatient = await repository.CreatePatient(new Patient() { Id = patient.Id, FullName = patient.FullName, Appointments = patient.Appointments });
                PatientDTO patientDTO = new PatientDTO() { Id = addPatient.Id, FullName = addPatient.FullName, Appointments = addPatient.Appointments };
                return TypedResults.Ok(addPatient);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound();
            }
        }



    }
}
