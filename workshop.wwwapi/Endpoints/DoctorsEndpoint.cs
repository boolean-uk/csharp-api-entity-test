using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorsEndpoint
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var dtos = doctors.Select(x => new GetDoctorDTO()
            {
                Name = x.Name
            });
            return TypedResults.Ok(dtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            try
            {
                return TypedResults.Ok(await repository.GetDoctorById(id));
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        public static async Task<IResult> AddDoctor(IRepository repository, GetDoctorDTO dto)
        {
            try
            {
                Doctor doctor = await repository.AddDoctor(dto);
                return TypedResults.Created(nameof(AddDoctor), dto);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
