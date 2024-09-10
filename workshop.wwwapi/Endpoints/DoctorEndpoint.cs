using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var doctors = app.MapGroup("doctors");

            doctors.MapGet("/GetAll", GetDoctors);
            doctors.MapGet("/GetById{id}", GetDoctor);
            doctors.MapPost("/Create", CreateDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            try
            {
                return TypedResults.Ok(await repository.GetDoctors());
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            try
            {
                return TypedResults.Ok(await repository.GetDoctor(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository repository, InputDTO data)
        {
            try
            {
                //Check if the name is empty
                if (data.FullName == string.Empty)
                {
                    return TypedResults.BadRequest();
                }

                //Check if the name is the same as any other name that already exists
                var doctors = await repository.GetDoctors();
                if (doctors != null)
                {
                    foreach (var doc in doctors)
                    {
                        if (doc.Name == data.FullName)
                        {
                            return TypedResults.BadRequest();
                        }
                    }
                }

                //Create a new doctor
                var doctor = new Doctor() { FullName = data.FullName };

                //Add the new doctor
                var result = await repository.AddDoctor(doctor);

                //Reponse
                return TypedResults.Created($"http://localhost:5045/doctors/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
