using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoints
    {
        public static void ConfigureDoctorEndpoints(this WebApplication app)
        {
            var doctors = app.MapGroup("/doctors");
            doctors.MapGet("", getDoctors);
            doctors.MapGet("/{id}", getDoctor);
            doctors.MapPost("", createDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> getDoctors(IDoctorRepo doctorRepo)
        {
            try
            {
                var doctors = await doctorRepo.GetDoctors();
                List<PatientDTO> DTOs = new List<PatientDTO>();
                foreach (var p in doctors)
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
        private static async Task<IResult> getDoctor(IDoctorRepo doctorRepo, int id)
        {
            try
            {
                var doctor = await doctorRepo.GetDoctor(id);
                PatientDTO patientDTO = new PatientDTO();
                patientDTO.Name = doctor.FullName;
                return TypedResults.Ok(patientDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        private static async Task<IResult> createDoctor(IDoctorRepo doctorRepo, DoctorDTO doctor)
        {
            try
            {
                DoctorDTO DTO = new DoctorDTO();
                var newDoctor = await doctorRepo.CreateDoctor(new Doctor() { FullName = doctor.Name });
                DTO.Name = newDoctor.FullName;

                return TypedResults.Ok(DTO);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
