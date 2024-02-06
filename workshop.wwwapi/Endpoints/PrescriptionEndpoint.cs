using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Repository.Implementation;
using workshop.wwwapi.Services;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        public static void ConfigurePrescriptionEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("/prescriptions");

            group.MapGet("/", GetAll);
            group.MapGet("/{id}", Get);
            group.MapPost("/", Create);
            group.MapPut("/{id}/medicines", AddMedicines);
            group.MapDelete("/{id}/medicines", RemoveMedicines);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IPrescriptionRepository repository)
        {
            IEnumerable<Prescription> prescriptions = await repository.Get();

            if (prescriptions.Count() == 0)
                return TypedResults.NotFound();

            IEnumerable<OutputPrescription> outputPrescriptions = PrescriptionDtoManager.Convert(prescriptions);
            return TypedResults.Ok(outputPrescriptions);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> Get(IPrescriptionRepository repository, int id)
        {
            Prescription? prescription = await repository.Get(id);

            if (prescription == null)
                return TypedResults.NotFound();

            OutputPrescription outputPrescription = PrescriptionDtoManager.Convert(prescription);
            return TypedResults.Ok(outputPrescription);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create(IPrescriptionRepository repository, IAppointmentRepository appointmentRepository, IMedicineRepository medicineRepository, InputPrescription inputPrescription)
        {
            Appointment? appointment = await appointmentRepository.Get(inputPrescription.AppointmentId);

            if (appointment == null)
                return TypedResults.BadRequest();

            List<Medicine> medicines = new List<Medicine>();
            foreach (var id in inputPrescription.MedicineIds)
            {
                var medicine = await medicineRepository.Get(id);
                if (medicine == null)
                {
                    return TypedResults.BadRequest($"Medicine with ID {id} not found");
                }
                medicines.Add(medicine);
            }

            Prescription prescription = new Prescription
            {
                Medicines = medicines,
                AppointmentId = inputPrescription.AppointmentId,
                Appointment = appointment
            };

            Prescription? result = await repository.Create(prescription);

            if (result == null)
                return TypedResults.BadRequest();

            OutputPrescription outputPrescription = PrescriptionDtoManager.Convert(result);
            return TypedResults.Created("url", outputPrescription);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddMedicines(int id, IPrescriptionRepository prescriptionRepository, IMedicineRepository medicineRepository, List<int> medicinesIds)
        {
            Prescription? prescription = await prescriptionRepository.Get(id);

            if (prescription == null)
                return TypedResults.NotFound();

            foreach (int medicineId in medicinesIds)
            {
                Medicine? medicine = await medicineRepository.Get(medicineId);
                if (medicine == null)
                    return TypedResults.BadRequest($"Medicine with ID {medicineId} not found");
            }

            foreach (int medicineId in medicinesIds)
            {
                Medicine? medicine = await medicineRepository.Get(medicineId);
                prescription.Medicines.Add(medicine);
            }

            Prescription result = await prescriptionRepository.Update(prescription);

            OutputPrescription outputPrescription = PrescriptionDtoManager.Convert(result);
            return TypedResults.Ok(outputPrescription);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> RemoveMedicines(int id, IPrescriptionRepository prescriptionRepository,  IMedicineRepository medicineRepository, [FromBody] List<int> medicinesIds)
        {
            Prescription? prescription = await prescriptionRepository.Get(id);

            if (prescription == null)
                return TypedResults.NotFound();

            foreach (int medicineId in medicinesIds)
            {
                Medicine? medicine = await medicineRepository.Get(medicineId);
                if (medicine == null)
                    return TypedResults.BadRequest($"Medicine with ID {medicineId} not found");
            }

            foreach (int medicineId in medicinesIds)
            {
                Medicine? medicine = await medicineRepository.Get(medicineId);
                prescription.Medicines.Remove(medicine);
            }

            Prescription result = await prescriptionRepository.Update(prescription);

            OutputPrescription outputPrescription = PrescriptionDtoManager.Convert(result);
            return TypedResults.Ok(outputPrescription);
        }
    }
}
