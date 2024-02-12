using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        public static void ConfigurePrescriptionEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("prescriptions");

            surgeryGroup.MapGet("/", GetPrescriptions);
            surgeryGroup.MapGet("/{id}", GetPrescription);
            surgeryGroup.MapPost("/", CreatePrescription);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            IEnumerable<Prescription> prescriptions = await repository.GetPrescriptions();
            List<PrescriptionDto> prescriptionDtos = prescriptions.Select(prescriptions => prescriptions.ToDto()).ToList();
            return TypedResults.Ok(prescriptionDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPrescription(IRepository repository, int id)
        {
            var prescription = await repository.GetPrescription(id);
            if (prescription == null) return TypedResults.NotFound();
            return TypedResults.Ok(prescription.ToDto());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePrescription(IRepository repository, int doctorId, int patientId, PrescriptionInput prescriptionData)
        {
            if (!(await repository.AppointmentExists(doctorId, patientId))) return TypedResults.BadRequest();
            
            var prescription = await repository.CreatePrescription(doctorId, patientId);
            var medicines = prescriptionData.medicines.Select(medicine => new MedicinePrescription
            {
                MedicineId = medicine.MedicineId,
                Quantity = medicine.Quantity,
                Usage = medicine.Usage,
                PrescriptionId = prescription.Id
            });

            foreach (var medicine in medicines)
            {
                if (!(await repository.MedicineExists(medicine.MedicineId))) return TypedResults.BadRequest();
                await repository.CreateMedicinePrescription(medicine);
            }

            var newPrescription = await repository.GetPrescription(prescription.Id);

            return TypedResults.Created($"/{prescription.Id}", newPrescription.ToDto());
        }
    }
}
