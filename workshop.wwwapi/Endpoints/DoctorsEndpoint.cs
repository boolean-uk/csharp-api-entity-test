using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorsEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigureDoctorsEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("doctors");

            group.MapGet("/", GetDoctors);
            group.MapGet("/{id}", GetDoctorById);
            group.MapPost("/", CreateDoctor);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor> repository, IMapper mapper)
        {
            try
            {
                var doctors = await repository.GetAll();

                if (!doctors.Any()) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<IEnumerable<DoctorDTO>>(doctors));
            }
            catch (Exception ex) 
            {
                return TypedResults.InternalServerError(ex);
            }
           
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetDoctorById(IRepository<Doctor> repository, IMapper mapper, int id)
        {
            try
            {
                var doctor = await repository.GetWithCustomQuery(p => p.Id == id, include: query => query.Include(p => p.Appointments).ThenInclude(a => a.Patient));

                if (doctor == null) return TypedResults.NotFound($"No doctor with id:{id} was found.");

                return TypedResults.Ok(mapper.Map<DoctorWithAppointmentsDTO>(doctor));
            }
            catch (Exception ex)
            {
                return TypedResults.InternalServerError(ex);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreateDoctor(IRepository<Doctor> repository, IMapper mapper, DoctorDTO entity)
        {
            try
            {
                Doctor newDoctor = new Doctor();
                newDoctor.FullName = entity.FullName;

                var patient = await repository.Add(newDoctor);

                return TypedResults.Created($"https://localhost:7235/patients/", mapper.Map<DoctorDTO>(patient));
            }
            catch (Exception ex)
            {
                return TypedResults.InternalServerError(ex);
            }

        }

    }
}
