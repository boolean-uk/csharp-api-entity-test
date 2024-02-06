using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Services;

namespace workshop.wwwapi.Endpoints
{
    public static class MedicineEndpoint
    {
        public static void ConfigureMedicineEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("/medicines");
            group.MapGet("/", GetAll);
            group.MapGet("/{id}", Get);
            group.MapPost("/", Post);
            group.MapPut("/{id}/prescriptions", AddPrescriptions);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IMedicineRepository repository)
        {
            IEnumerable<Medicine> medicines = await repository.Get();

            if (medicines.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputMedicine> outputMedicines = MedicineDtoManager.Convert(medicines);
            return TypedResults.Ok(outputMedicines);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(IMedicineRepository repository, int id)
        {
            Medicine? medicine = await repository.Get(id);

            if (medicine == null)
                return TypedResults.NotFound();

            OutputMedicine outputMedicine = MedicineDtoManager.Convert(medicine);
            return TypedResults.Ok(outputMedicine);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Post(IMedicineRepository repository, InputMedicine inputMedicine)
        {
            Medicine newMedicine = new Medicine
            {
                Name = inputMedicine.Name,
                Quantity = inputMedicine.Quantity,
                Notes = inputMedicine.Notes
            };

            Medicine? result = await repository.Create(newMedicine);

            if (result == null)
                return TypedResults.BadRequest();

            OutputMedicine outputMedicine = MedicineDtoManager.Convert(result);
            return TypedResults.Created("url", outputMedicine);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddPrescriptions(int id, IMedicineRepository medicineRepository, IPrescriptionRepository prescriptionRespository, List<int> prescriptionsIds)
        {
            Medicine? medicine = await medicineRepository.Get(id);

            if (medicine == null)
                return TypedResults.NotFound("Medicine not found");

            // Check if all prescriptions exist
            foreach (int prescriptionId in prescriptionsIds)
            {
                Prescription? prescription = await prescriptionRespository.Get(prescriptionId);
                if (prescription == null)
                    return TypedResults.BadRequest($"Prescription with ID {prescriptionId} not found");
            }

            // Add prescriptions to medicine
            foreach (int prescriptionId in prescriptionsIds)
            {
                Prescription? prescription = await prescriptionRespository.Get(prescriptionId);
                medicine.Prescriptions.Add(prescription);
            }

            var result = await medicineRepository.Update(medicine);

            OutputMedicine outputMedicine = MedicineDtoManager.Convert(result);
            return TypedResults.Ok(outputMedicine);
        }
    }
}
