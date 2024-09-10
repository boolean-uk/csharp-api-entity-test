using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
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
            perscription.MapPut("/Attach{perscriptionId}To{appointmentId}", AttachPerscription);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPerscriptions(IRepository repository)
        {
            try
            {
                return TypedResults.Ok(await repository.GetPerscriptions());
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreatePerscription(IRepository repository, InputPerscriptionDTO data)
        {
            try
            {
                //If the data is empty
                if(data.medicineIds.Count == 0)
                {
                    TypedResults.BadRequest();
                }

                //Create a new perscription
                var perscription = new Perscription();

                //Get the medicines
                var medicines = await repository.GetMedicines();

                //Check if each medicine exists
                foreach(var med in medicines)
                {
                    bool found = false;
                    foreach(var id in data.medicineIds)
                    {
                        if(med.Id == id)
                        {
                            found = true;
                            continue;
                        }
                    }
                    if(!found)
                    {
                        TypedResults.NotFound();
                    }
                }

                //Create the perscription
                var result = await repository.AddPerscription(perscription);

                //Update the perscription
                result = await repository.UpdatePerscription(result.Id, data.medicineIds);

                //Reponse
                return TypedResults.Created($"http://localhost:5045/perscription/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> AttachPerscription(IRepository repository, int perscriptionId, int appointmentId)
        {
            try
            {
                //Attach the perscription to the appointment
                var result = await repository.AttachPerscription(perscriptionId, appointmentId);

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
