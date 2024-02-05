using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.JunctionTable;
using workshop.wwwapi.Models.PureModels;
using workshop.wwwapi.Models.TransferInputModels;
using workshop.wwwapi.Models.TransferModels.Items;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        public static void ConfigurePrescriptionsEndpoint(this WebApplication app)
        {
            var prescriptionGroup = app.MapGroup("prescriptions");

            prescriptionGroup.MapGet("/", GetPrescriptions);
            prescriptionGroup.MapGet("/{id}", GetSpecificPrescription);
            prescriptionGroup.MapPost("/", PostPrescription);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            IEnumerable<Prescription> prescriptions = await repository.GetPrescriptions();

            IEnumerable<PrescriptionDTO> prescriptOut = prescriptions.Select(p => new PrescriptionDTO(p.Id, p.Name, p.Appointment, p.PrescriptionMedicine)).ToList();
            Payload<IEnumerable<PrescriptionDTO>> payload = new Payload<IEnumerable<PrescriptionDTO>>(prescriptOut);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetSpecificPrescription(IRepository repository, int id)
        {
            Prescription? prescription = await repository.GetSpecificPrescription(id);
            if (prescription == null)
            {
                return TypedResults.NotFound($"No prescription of provided ID {id} was found.");
            }

            PrescriptionDTO prescriptOut = new PrescriptionDTO(
                prescription.Id,
                prescription.Name,
                prescription.Appointment,
                prescription.PrescriptionMedicine);
            Payload<PrescriptionDTO> payload = new Payload<PrescriptionDTO>(prescriptOut);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> PostPrescription(IRepository repository, PrescriptionInputDTO scriptPost)
        {
            IEnumerable<Medicine> meds = await repository.GetMedicines();
            bool validMedicineId = scriptPost.prescriptionMedicine.All(m => meds.Any(n => n.Id == m.MedicineId));
            if (!validMedicineId)
            {
                return TypedResults.NotFound($"Could not find medicines with provided ids of {string.Join(", ", scriptPost.prescriptionMedicine.Select(m => m.MedicineId))}.");
            }
            IEnumerable<Appointment> apps = await repository.GetAppointments();
            bool validAppointmentId = apps.Any(a => a.Id == scriptPost.AppointmentId);
            if (!validAppointmentId)
            {
                return TypedResults.NotFound($"Could not find appointment with provided id of {validAppointmentId}.");
            }

            Prescription prescription = new Prescription() { Name = scriptPost.Name, AppointmentId = scriptPost.AppointmentId, DoctorId = scriptPost.DoctorId, PatientId = scriptPost.PatientId };
            Prescription scriptReturn = await repository.PostPrescription(prescription);

            IEnumerable<PrescriptionMedicine> prescriptions = scriptPost
                .prescriptionMedicine
                .Select(pm => new PrescriptionMedicine()
                {
                    PrescriptionId = scriptReturn.Id,
                    MedicineId = pm.MedicineId,
                    Amount = pm.Amount,
                    Instructions = pm.Instructions
                });

            List<PrescriptionMedicine> postPrescriptionReturn = new List<PrescriptionMedicine>();
            foreach (PrescriptionMedicine pm in prescriptions)
            {
                postPrescriptionReturn.Add(await repository.PostPrescriptionMedicine(pm));
            }


            PrescriptionDTO scriptOut = new PrescriptionDTO(scriptReturn.Id, scriptReturn.Name, scriptReturn.Appointment, postPrescriptionReturn);
            Payload<PrescriptionDTO> payload = new Payload<PrescriptionDTO>(scriptOut);
            return TypedResults.Created($"/{payload.Data.Id}", payload);
        }
    }
}
