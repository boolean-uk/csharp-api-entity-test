using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
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
            prescription.MapGet("/Get{id}", GetPrescription);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPrescriptions());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreatePrescription(IRepository repository, int appointmentId,
            List<int> medineIds) 
        {
            foreach (var med in medineIds)
            {
                if(!await repository.CheckExists(4, med))
                {
                    return TypedResults.NotFound();
                }
            }
            if(!await repository.CheckExists(3, appointmentId))
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(await repository.CreatePrescription(appointmentId, medineIds));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPrescription(IRepository repository, int id)
        {
            var result = await repository.GetPrescription(id);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(result);
        }
    }
}
