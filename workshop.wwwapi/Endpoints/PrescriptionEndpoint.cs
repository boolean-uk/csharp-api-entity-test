using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        public static void ConfigurePrescriptionEndpoint(this WebApplication app)
        {
            var prescription = app.MapGroup("Prescription");

            prescription.MapGet("/GetAll", GetPrescriptions);
            prescription.MapPost("/Create", CreatePrescription);
            prescription.MapPut("/Attach{id}", AttachPrescription);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
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
        public static async Task<IResult> CreatePrescription(IRepository repository, InputDTO data) //New DTO for Prescription needed
        {
            try
            {


                //Reponse
                return TypedResults.Created($"http://localhost:5045/Prescription/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AttachPrescription(IRepository repository, InputDTO data, int appointmentId) //New DTO for Prescription needed
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
