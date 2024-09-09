using Microsoft.AspNetCore.Builder;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoints
    {
        public static void ConfigurePatientEndpoints(this WebApplication app)
        {
            var patients = app.MapGroup("/patients");
            patients.MapGet("", getPatients);
            patients.MapGet("/{id}", getPatient);
            patients.MapPost("", createPatient);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> getPatients(IPatientRepo patientRepo)
        {
            try
            {
                var patients = await patientRepo.GetPatients();
                List<PatientDTO> DTOs = new List<PatientDTO>();
                foreach (var p in patients)
                {

                    PatientDTO patientDTO = new PatientDTO();
                    patientDTO.Name = p.FullName;
                    DTOs.Add(patientDTO);
                }
                return TypedResults.Ok(DTOs);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> getPatient(IPatientRepo patientRepo, int id) 
        {
            try
            {
                var patient = await patientRepo.GetPatient(id);
                PatientDTO patientDTO = new PatientDTO();
                patientDTO.Name = patient.FullName;
                return TypedResults.Ok(patientDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        private static async Task<IResult> createPatient(IPatientRepo patientRepo, PatientDTO patient)
        {
            try
            {
                PatientDTO patientDTO = new PatientDTO();
                var newPatient = await patientRepo.CreatePatient(new Patient() { FullName = patient.Name });
                patientDTO.Name = newPatient.FullName;

                return TypedResults.Ok(patientDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }



    }
}
