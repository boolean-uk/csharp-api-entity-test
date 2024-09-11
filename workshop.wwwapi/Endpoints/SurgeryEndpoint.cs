using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModels;

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
            surgeryGroup.MapPost("/patients", AddPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            GetPatientsResponse patientsResponse = new GetPatientsResponse();
            var patients = await repository.GetPatients();

            foreach (Patient patient in patients)
            {
                DTOPatient dtoPatient = new DTOPatient() { ID = patient.Id, Name = patient.FullName };
                patientsResponse.Patients.Add(dtoPatient);
            }
            return TypedResults.Ok(patientsResponse);
        }

        [Route("/patients{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(int id, IRepository repotistory)
        {
            Patient patient = await repotistory.GetPatientById(id);

            if (patient != null)
            {
                DTOPatient dtoPatient = new DTOPatient() { ID = patient.Id, Name = patient.FullName };
                return TypedResults.Ok(patient);
            }
            return TypedResults.NotFound(new Message());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddPatient(IRepository repository, PatientPostModel model)
        {
            try
            {
                Patient patient = await repository.AddPatient(new Patient() { FullName = model.Name });

                return TypedResults.Created("", new DTOPatient() { ID = patient.Id, Name = patient.FullName });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
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
