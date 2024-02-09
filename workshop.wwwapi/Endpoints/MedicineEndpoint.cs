using workshop.wwwapi.Repository;
using workshop.wwwapi.DTO;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
namespace workshop.wwwapi.Endpoints
{
    public static class MedicineEndpoint
    {
        public static void ConfigureMedicineEndpoint(this WebApplication app)
        {
            var medicineGroup = app.MapGroup("surgery");

            medicineGroup.MapGet("/medicines", GetMedicines);
            medicineGroup.MapGet("/medicines/{id}", GetMedicineById);
            medicineGroup.MapPost("/medicines", CreateMedicine);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetMedicines(IRepository repository)
        { 
            var medicines = await repository.GetMedicines();
            var MedicineDTO = new List<MedicineDTO>();
            foreach (Medicine medicine in medicines)
            {
                MedicineDTO.Add(new MedicineDTO(medicine));
            }
            return TypedResults.Ok(MedicineDTO);
        }

        public static async Task<IResult> GetMedicineById(IRepository repository ,int id)
        {
            if (id <= 0)
            {
                return TypedResults.BadRequest("Id must be greater than 0");
            }
            if (id == null)
            {
                return TypedResults.NotFound();
            }
            var medicine = await repository.GetMedicineById(id, PreloadPolicy.PreloadRelations);
            var medicineDTO = new MedicineDTO(medicine);
            return TypedResults.Ok(medicineDTO);
        }

        public static async Task<IResult> CreateMedicine(CreateMedicinePayload payload ,IRepository repository)
        {
            if (string.IsNullOrEmpty(payload.Name))
            {
                return TypedResults.BadRequest("Name is required");
            }
            Medicine? medicine = await repository.CreateMedicine(payload.Name);
            if (medicine == null)
            {
                return TypedResults.BadRequest("Medicine could not be created");
            }
            return TypedResults.Ok(new MedicineDTO(medicine));
        }


    }
}