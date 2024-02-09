using workshop.wwwapi.Repository;
using workshop.wwwapi.DTO;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        public static void ConfigurePrescriptionEndpoint(this WebApplication app)
        {
            var prescriptionGroup = app.MapGroup("surgery");

            prescriptionGroup.MapGet("/prescriptions", GetPrescriptions);
            prescriptionGroup.MapGet("/prescriptions/{id}", GetPrescriptionById);
            prescriptionGroup.MapPost("/prescriptions", CreatePrescription);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        { 
            var prescriptions = await repository.GetPrescriptions();
            var PrescriptionDTO = new List<PrescriptionDTO>();
            foreach (Prescription prescription in prescriptions)
            {
                PrescriptionDTO.Add(new PrescriptionDTO(prescription));
            }
            return TypedResults.Ok(PrescriptionDTO);
        }

        public static async Task<IResult> GetPrescriptionById(IRepository repository, int id)
        {
            if (id <= 0)
            {
                return TypedResults.BadRequest("Id must be greater than 0");
            }
            if (id == null)
            {
                return TypedResults.NotFound();
            }
            var prescription = await repository.GetPrescriptionById(id, PreloadPolicy.PreloadRelations);
            var prescriptionDTO = new PrescriptionDTO(prescription);
            return TypedResults.Ok(prescriptionDTO);
        }

        public static async Task<IResult> CreatePrescription(int medicineId, CreatePrescriptionPayload payload ,IRepository repository)
        {
            if (string.IsNullOrEmpty(payload.Notes))
            {
                return TypedResults.BadRequest("Notes is required");
            }
            if (payload.Quantity <= 0)
            {
                return TypedResults.BadRequest("Quantity must be greater than 0");
            }
            if (medicineId <= 0)
            {
                return TypedResults.BadRequest("MedicineId must be greater than 0");
            }
            Prescription? prescription = await repository.CreatePrescription(medicineId, payload.Quantity, payload.Notes);
            if (prescription == null)
            {
                return TypedResults.BadRequest("Prescription could not be created");
            }
            return TypedResults.Ok(new PrescriptionDTO(prescription));
        }

    }
}