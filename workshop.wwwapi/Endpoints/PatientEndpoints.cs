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
                List<GenericDTO> DTOs = new List<GenericDTO>();
                
                foreach (var p in patients)
                {
                    GenericDTO patientDTO = new GenericDTO();
                    patientDTO.Name = p.FullName;
                    patientDTO.Appointments = new List<GenericAppointmentDTO>();

                    
                    foreach(var ap in p.Appointments)
                    {
                        GenericAppointmentDTO appointmentDTO = new GenericAppointmentDTO();
                        appointmentDTO.Booking = ap.Booking;
                        
                        appointmentDTO.Name = ap.Doctor.FullName;
                        patientDTO.Appointments.Add(appointmentDTO);
                    }
                    
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
                GenericDTO patientDTO = new GenericDTO();
                patientDTO.Name = patient.FullName;
                patientDTO.Appointments = new List<GenericAppointmentDTO>();
                foreach(var ap in patient.Appointments)
                {
                    GenericAppointmentDTO appointmentDTO = new GenericAppointmentDTO();
                    appointmentDTO.Booking = ap.Booking;

                    appointmentDTO.Name = ap.Doctor.FullName;
                    patientDTO.Appointments.Add(appointmentDTO);
                }
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
