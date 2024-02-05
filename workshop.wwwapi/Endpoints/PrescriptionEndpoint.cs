using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
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
        public static async Task<IResult> Create(IPrescriptionRepository repository, IAppointmentRepository appointmentRepository, InputPrescription inputPrescription)
        {
            Appointment? appointment = await appointmentRepository.Get(inputPrescription.AppointmentId);

            if (appointment == null)
                return TypedResults.BadRequest();

            Prescription prescription = new Prescription
            {
                Medicines = inputPrescription.Medicines.Select(medicine => new Medicine
                {
                    Name = medicine.Name,
                    Quantity = medicine.Quantity,
                    Notes = medicine.Notes
                }).ToList(),

                AppointmentId = inputPrescription.AppointmentId,
                Appointment = appointment
            };

            Prescription? result = await repository.Create(prescription);

            if (result == null)
                return TypedResults.BadRequest();

            OutputPrescription outputPrescription = PrescriptionDtoManager.Convert(result);
            return TypedResults.Created();
        }
    }
}
