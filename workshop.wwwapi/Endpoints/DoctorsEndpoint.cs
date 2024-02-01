using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorsEndpoint
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IGeneralRepository<Doctor> repository)
        {
            var doctors = await repository.GetAll();
            var dtos = doctors.Select(x => new GetDoctorDTO()
            {
                Name = x.Name
            });
            return TypedResults.Ok(dtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctor(IGeneralRepository<Doctor> repository, int id)
        {
            try
            {
                return TypedResults.Ok(await repository.GetById(id));
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        public static async Task<IResult> AddDoctor(IGeneralRepository<Doctor> repository, GetDoctorDTO dto)
        {
            try
            {
                Doctor doctor = new()
                {
                    Name = dto.Name,
                };
                await repository.Add(doctor);
                return TypedResults.Created(nameof(AddDoctor), dto);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
