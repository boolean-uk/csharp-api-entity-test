using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        public static void ConfigurePrescriptionEndpoint(this WebApplication app)
        {
            var prescriptionGroup = app.MapGroup("prescription");

            prescriptionGroup.MapGet("/", GetPrescriptions);
            prescriptionGroup.MapPost("/", AddPrescription);
           

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {

            //Soruce:
            var source = await repository.Getprescriptions();
            //Target & Transferring:

            List<OutPrescriptionDTO> prescriptions = source.Select(a => new OutPrescriptionDTO
            {
                PrescriptMed = a.PrescriptMed.Select(p => new OutPrescriptionMedicineDTO
                {
                    MedicineId = p.MedicineId,
                    Note = p.Note,
                    Quatity = p.Quatity
                }).ToList()


            }).ToList();

            return TypedResults.Ok(prescriptions);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddPrescription(IRepository repository, [FromBody] InPrescriptionDTO newPrescription)
        {
            try
            {
                //Soruce:
                var result = await repository.AddPrescription(newPrescription);

                return TypedResults.Created(nameof(AddPrescription), newPrescription);
            }
            catch (ArgumentException ex) { return TypedResults.BadRequest(ex.Message); }
            //catch (BadHttpRequestException ex) { return TypedResults.BadRequest(ex.Message); }

        }

    }
}
