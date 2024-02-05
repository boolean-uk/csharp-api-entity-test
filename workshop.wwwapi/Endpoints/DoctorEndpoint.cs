using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.DTO;
namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoint
    {
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var DoctorDTO = new List<DoctorDTO>();
            foreach (Doctor doctor in doctors)
            {
                DoctorDTO.Add(new DoctorDTO(doctor));
            }
            return TypedResults.Ok(DoctorDTO);
        }

        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorById(id, PreloadPolicy.PreloadRelations);
            var doctorDTO = new DoctorDTO(doctor);
            return TypedResults.Ok(doctorDTO);
        }

        public static async Task<IResult> CreateDoctor(CreateDoctorPayload payload, IRepository repository)
        {
            if (string.IsNullOrEmpty(payload.FullName))
            {
                return TypedResults.BadRequest("Full name is required");
            }
            Doctor? doctor = await repository.CreateDoctor(payload.FullName);
            if (doctor == null)
            {
                return TypedResults.BadRequest("Doctor could not be created");
            }
            return TypedResults.Ok(new DoctorResponseDTO(doctor));
        }
    }
}