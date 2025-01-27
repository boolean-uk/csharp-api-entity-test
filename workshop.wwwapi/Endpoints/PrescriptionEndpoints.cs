using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Exceptions;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoints
    {
        public static string Path { get; private set; } = "prescriptions";

        public static void ConfigurePrescriptionsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(Path);

            group.MapPost("/", CreatePrescription);
            group.MapGet("/", GetPrescriptions);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreatePrescription(
            IRepository<Prescription, int> repository,
            IRepository<Appointment, int> appointmentRepository,
            IRepository<Medicine, int> medicineRepository,
            IMapper mapper, 
            PrescriptionPost entity)
        {
            try
            {
                Appointment appointment = await appointmentRepository.Find(a => a.PatientId == entity.AppointmentPatientId && a.DoctorId == entity.AppointmentDoctorId);
                Medicine medicine = await medicineRepository.Get(entity.MedicineId);
                Prescription prescription = await repository.Add(new Prescription
                {
                    AppointmentDoctorId = appointment.DoctorId,
                    AppointmentPatientId = appointment.PatientId,
                    Notes = entity.Notes,
                    Quantity = entity.Quantity,
                    Medicines = [medicine]
                });
                prescription = await repository.GetWithIncludes(prescription.Id,
                    q => q.Include(x => x.Appointment).ThenInclude(x => x.Doctor),
                    q => q.Include(x => x.Appointment).ThenInclude(x => x.Patient)
                );
                return TypedResults.Created($"/{Path}", mapper.Map<PrescriptionView>(prescription));
            } catch (IdNotFoundException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetPrescriptions(IRepository<Prescription, int> repository, IMapper mapper)
        {
            try
            {
                IEnumerable<Prescription> prescriptions = await repository.GetAllWithIncludes(
                    q => q.Include(x => x.Medicines),
                    q => q.Include(x => x.Appointment).ThenInclude(x => x.Doctor),
                    q => q.Include(x => x.Appointment).ThenInclude(x => x.Patient)
                );
                return TypedResults.Ok(mapper.Map<List<PrescriptionView>>(prescriptions));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
