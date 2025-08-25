using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;


[ApiController]
//Should be named DoctorController but i decided to keep it like this for now
//since it works
[Route("api/[controller]")]
public class PrescriptionEndpoint : ControllerBase
{
    private readonly DatabaseContext _context;

    public PrescriptionEndpoint(DatabaseContext context)
    {
        _context = context;
    }

[HttpGet]
public async Task<ActionResult<IEnumerable<PrescriptionDTO>>> GetAllPrescriptions()
{
    var prescriptions = await _context.Prescriptions
        .Include(p => p.Appointment)
            .ThenInclude(a => a.Patient)
        .Include(p => p.PrescriptionMedicines)
            .ThenInclude(pm => pm.Medicine)
        .Select(p => new PrescriptionDTO
        {
            Id = p.Id,
            AppointmentId = p.AppointmentId,
            PatientName = p.Appointment.Patient.FullName,
            Medicines = p.PrescriptionMedicines.Select(pm => new PrescriptionMedicineDTO
            {
                MedicineId = pm.MedicineId,
                MedicineName = pm.Medicine.Name,
                Quantity = pm.Quantity,
                Notes = pm.Notes
            }).ToList()
        })
        .ToListAsync();

    return Ok(prescriptions);
}
}