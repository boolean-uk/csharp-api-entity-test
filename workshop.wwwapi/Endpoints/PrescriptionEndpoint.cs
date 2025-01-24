using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        public static void ConfigurePrescriptionEndpoint(this WebApplication app)
        {
            var pres = app.MapGroup("/prescriptions");

            pres.MapGet("/", GetPrescriptions);
            pres.MapPost("/", AddPrescription);
            //pres.MapGet("prescription/patient/{id}", GetPrescriptionsForPatient);
            //pres.MapGet("prescription/doctor/{id}", GetPrescriptionsForDoctor);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository<Prescription> repository)
        {
            var prescriptions = await repository.GetWithThenIncludes(
                q => q.Include(p => p.Appointment).ThenInclude(a => a.Patient),
                q => q.Include(p => p.Appointment).ThenInclude(a => a.Doctor),
                q => q.Include(p => p.Medicines)
                );

            return TypedResults.Ok(
               prescriptions
                .Select(p => new PrescriptionDto()
                {
                    Date = p.Appointment.Booking,
                    Medicines = p.Medicines.Select(m => new MedicineDto()
                    {
                        Name = m.Name,
                        Quantity = p.MedicinePresciptions.FirstOrDefault(mp => mp.MedicineId == m.Id).Quantity,
                        Description = p.MedicinePresciptions.FirstOrDefault(mp => mp.MedicineId == m.Id).Notes
                    }).ToList(),
                    Doctor = p.Appointment.Doctor.FullName,
                    Patient = p.Appointment.Patient.FullName
                }));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddPrescription(IRepository<Prescription> prescriptionRepository, IRepository<Medicine> medicineRepository, IRepository<MedicinePresctiption> medicinePrescriptionRepository, List<MedicinePrescriptionDto> mpDTO, int appointmentId)
        {
            var prescription = new Prescription()
            {
                AppointmentId = appointmentId,
            };

            await prescriptionRepository.Insert(prescription);
            var MedicinePrescriptions = new List<MedicinePresctiption>();

            MedicinePrescriptions = mpDTO.Select(mp => new MedicinePresctiption()
            {
                MedicineId = mp.MedicineId,
                PrescriptionId = prescription.Id,
                Quantity = mp.Quantity,
                Notes = mp.Notes
            }).ToList();

            await medicinePrescriptionRepository.InsertAll(MedicinePrescriptions);
            var response = new MedicinePrescriptionResponseDto()
            {
                Doctor = prescription.Appointment.Doctor.FullName,
                Patient = prescription.Appointment.Patient.FullName,
                Date = prescription.Appointment.Booking,
                Medicines = MedicinePrescriptions.Select(mp => new MedicinePrescriptionDto()
                {
                    MedicineId = mp.MedicineId,
                    Quantity = mp.Quantity,
                    Notes = mp.Notes

                }).ToList()
            };
            return TypedResults.Created("somepath", response );
        }
    }
}
