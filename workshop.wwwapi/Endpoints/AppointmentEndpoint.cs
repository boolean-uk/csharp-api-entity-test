using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using workshop.wwwapi.Models.DataTransfer.Appointment;
using workshop.wwwapi.Models.DataTransfer.PrescriptionMedicine;
using workshop.wwwapi.Models.Domain;
using workshop.wwwapi.Models.Domain.Junctions;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("appointments");
            group.MapGet("/", GetAll);
            group.MapGet("/{id}", Get);
            group.MapPost("/", Create);
            group.MapGet("/{id}/prescriptions", GetPrescriptions);
            group.MapPost("/{id}/prescriptions", AddPrescription);
        }

        private static async Task<IResult> GetAll(IRepository<Appointment> repository)
        {
            var appointments = await repository.GetAll();
            List<AppointmentWithDoctorAndPatientDTO> results = new List<AppointmentWithDoctorAndPatientDTO>();
            foreach (var appointment in appointments)
            {
                results.Add(new AppointmentWithDoctorAndPatientDTO(appointment));
            }
            return TypedResults.Ok(results);
        }

        private static async Task<IResult> Get(IRepository<Appointment> repository, int id)
        {
            var result = await repository.Get(id);
            return TypedResults.Ok(new AppointmentWithDoctorAndPatientDTO(result));
        }

        private static async Task<IResult> Create(IRepository<Appointment> repository, AppointmentInsertDTO appointmentInput)
        {
            DateTime appointmentTime = new DateTime(appointmentInput.year, appointmentInput.month, appointmentInput.day, appointmentInput.hour, appointmentInput.minute, 0);
            appointmentTime = DateTime.SpecifyKind(appointmentTime, DateTimeKind.Utc);
            Appointment appointment = new Appointment() { AppointmentTime = appointmentTime, DoctorID = appointmentInput.DoctorID, PatientID = appointmentInput.PatientID };
            var result = await repository.Insert(appointment);
            return TypedResults.Created(result.ID.ToString(), new AppointmentWithDoctorAndPatientDTO(result));
        }

        private static async Task<IResult> GetPrescriptions(IPrescriptionRepository prescriptionRepository, IPrescriptionMedicineRepository prescriptionMedicineRepository, int id)
        {
            var prescription = await prescriptionRepository.GetByAppointmentID(id);
            if (prescription == null) return TypedResults.Ok(prescription);
            var prescriptionMedicines = await prescriptionMedicineRepository.GetAllByPrescriptionID(prescription.ID);
            List<PrescriptionMedicineDetailedDTO> results = new List<PrescriptionMedicineDetailedDTO>();
            foreach (var pm in  prescriptionMedicines)
            {
                results.Add(new PrescriptionMedicineDetailedDTO(pm));
            }
            return TypedResults.Ok(results);
        }

        private static async Task<IResult> AddPrescription([FromServices]IPrescriptionRepository prescriptionRepository, [FromServices]IRepository<Medicine> medicineRepository, [FromServices]IPrescriptionMedicineRepository prescriptionMedicineRepository, [FromRoute] int id, [FromBody] PrescriptionMedicineInsertDTO input)
        {
            var medicine = await medicineRepository.Get(input.MedicineID);
            if (medicine == null) return TypedResults.BadRequest($"No medicine with id={input.MedicineID} could be found.");
            var prescription = await prescriptionRepository.GetByAppointmentID(id);
            if (prescription == null)
            {
                prescription = await prescriptionRepository.Insert(new Prescription() { AppointmentID = id });
            }
            else
            {
                var prescriptionMedicine = await prescriptionMedicineRepository.Get(prescription.ID, input.MedicineID);
                if (prescriptionMedicine != null) return TypedResults.BadRequest($"Prescription with medicineID={input.MedicineID} already exists");

            }
            var result = prescriptionMedicineRepository.Insert(new PrescriptionMedicine() { MedicineID = input.MedicineID, PrescriptionID = prescription.ID, Quantity = input.Quantity, NoteFromDoctor = input.InstructionsFromDoctor });
            return TypedResults.Created($"{prescription.ID}{input.MedicineID}", new PrescriptionMedicineDetailedDTO(result.Result));
        }
    }
}
