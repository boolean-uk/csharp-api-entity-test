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
            doctors.MapGet("", GetAllDoctors);
            doctors.MapGet("/{id}", GetADoctor);
            doctors.MapPost("", CreateDoctor);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAllDoctors(IDoctorRepository doctorRepository)
        {
            try
            {
                var doctors = await doctorRepository.GetAllDoctors();

                List<DoctorDTO> ds = new List<DoctorDTO>();

                foreach (var d in doctors)
                {
                    DoctorDTO doctorDTO = new DoctorDTO();
                    doctorDTO.Name = d.FullName;
                    ds.Add(doctorDTO);
                }

                return TypedResults.Ok(ds);
            }
            catch (Exception ex)
            {

                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetADoctor(IDoctorRepository doctorRepository, int id)
        {
            try
            {
                var target = await doctorRepository.GetDoctorById(id);

                DoctorDTO doctorDTO = new DoctorDTO();

                doctorDTO.Name = target.FullName;

                return TypedResults.Ok(doctorDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Patient not found!");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> CreateDoctor(IDoctorRepository doctorRepository, DoctorDTO newDoctor)
        {
            try
            {
                DoctorDTO doctorDTO = new DoctorDTO();

                var result = await doctorRepository.CreateDoctor(new Doctor { FullName = newDoctor.Name });

                doctorDTO.Name = result.FullName;

                return TypedResults.Ok(doctorDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
