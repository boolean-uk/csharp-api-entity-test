using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoints
    {

        public static void ConfigurePatientEndpoints(this WebApplication app)
        {
            var patients = app.MapGroup("/patients");
            patients.MapGet("", GetAllPatients);
            patients.MapGet("/{id}", GetAPatient);
            patients.MapPost("", CreatePatient);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAllPatients(IPatientRepository patientRepository)
        {
            try
            {
                var patients = await patientRepository.GetAllPatients();

                List<GenericDTO> ps = new List<GenericDTO>();

                foreach (var p in patients)
                {
                    GenericDTO patientDTO = new GenericDTO();
                    patientDTO.FullName = p.FullName;
                    patientDTO.Appointments = new List<GenericAppointmentDTO>();
                    
                    foreach (var ap in p.Appointments) {

                        GenericAppointmentDTO apDTO = new GenericAppointmentDTO();
                        apDTO.appointmentDate = ap.ApointementDate;
                      
                        apDTO.FullName = ap.Doctor.FullName;
                        patientDTO.Appointments.Add(apDTO);
                    }

                    ps.Add(patientDTO);
                }

                return TypedResults.Ok(ps);
            }
            catch (Exception ex)
            {

                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetAPatient(IPatientRepository patientRepository, int id)
        {
            try
            {
                var target = await patientRepository.GetPatientById(id);

                GenericDTO patientDTO = new GenericDTO();

                patientDTO.FullName = target.FullName;

                patientDTO.Appointments = new List<GenericAppointmentDTO>();

                foreach (var ap in target.Appointments)
                {
                    GenericAppointmentDTO apDTO = new GenericAppointmentDTO();
                    apDTO.appointmentDate = ap.ApointementDate;

                    apDTO.FullName = ap.Doctor.FullName;
                    patientDTO.Appointments.Add(apDTO);
                }

                return TypedResults.Ok(patientDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Patient not found!");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> CreatePatient(IPatientRepository patientRepository, PatientDTO newPatient)
        {
            try
            {
                PatientDTO patientDTO = new PatientDTO();

                var result = await patientRepository.CreatePatient(new Patient { FullName=newPatient.FullName });
                
                patientDTO.FullName = result.FullName;

                return TypedResults.Ok(patientDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
