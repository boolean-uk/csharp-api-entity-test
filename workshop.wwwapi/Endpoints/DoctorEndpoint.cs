using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoint
    {
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("doctors");

            surgeryGroup.MapGet("/", GetDoctors);
            surgeryGroup.MapGet("/{id}", GetDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            IEnumerable<Doctor> doctors = await repository.GetDoctors();
            List<DoctorDto> doctorDtos = doctors.Select(doctors => doctors.ToDto()).ToList();
            return TypedResults.Ok(doctorDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctor(id);
            if (doctor == null) return TypedResults.NotFound();
            return TypedResults.Ok(doctor.ToDto());
        }
    }
}
