using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModel;

namespace workshop.wwwapi.Endpoints
{
    public static class PerscriptionEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePerscriptionEndpoint(this WebApplication app)
        {
            var perscription = app.MapGroup("perscription");

            perscription.MapGet("/GetAll", GetPerscriptions);
            perscription.MapPost("/Create", CreatePerscription);
            perscription.MapPut("/Attach{id}", AttachPerscription);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPerscriptions(IRepository repository)
        {
            try
            {
                return TypedResults.Ok(await repository.GetPatients());
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePerscription(IRepository repository, InputDTO data) //New DTO for perscription needed
        {
            try
            {
                

                //Reponse
                return TypedResults.Created($"http://localhost:5045/patients/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AttachPerscription(IRepository repository, InputDTO data, int appointmentId) //New DTO for perscription needed
        {
            try
            {


                //Reponse
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
