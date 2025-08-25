using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;


[ApiController]
//Should be named AppointmentController but i decided to keep it like this for now
//since it works
[Route("api/[controller]")]
public class AppointmentEndpoint : ControllerBase
{
    private readonly DatabaseContext _context;
    public AppointmentEndpoint(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAllAppointments()
    {
        var appointments = await _context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .Select(a => new AppointmentDto
            {
                Id = a.Id,
                Booking = a.Booking,
                Doctor = new DoctorDTO { Id = a.Doctor.Id, FullName = a.Doctor.FullName },
                Patient = new PatientDTO { Id = a.Patient.Id, FullName = a.Patient.FullName }
            })
            .ToListAsync();

        return Ok(appointments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentDto>> GetAppointmentById(int appointmentId)
    {
        var appointment = await _context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .Where(a => a.Id == appointmentId)
            .Select(a => new AppointmentDto
            {
                Id = a.Id,
                Booking = a.Booking,
                Doctor = new DoctorDTO { Id = a.Doctor.Id, FullName = a.Doctor.FullName },
                Patient = new PatientDTO { Id = a.Patient.Id, FullName = a.Patient.FullName }
            })
            .FirstOrDefaultAsync();

        if (appointment == null)
            return NotFound();

        return Ok(appointment);
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByDoctorId(int doctorId)
    {
        var appointments = await _context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .Where(a => a.DoctorId == doctorId)
            .Select(a => new AppointmentDto
            {
                Id = a.Id,
                Booking = a.Booking,
                Doctor = new DoctorDTO { Id = a.Doctor.Id, FullName = a.Doctor.FullName },
                Patient = new PatientDTO { Id = a.Patient.Id, FullName = a.Patient.FullName }
            })
            .ToListAsync();

        return Ok(appointments);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByPatientId(int patientId)
    {
        var appointments = await _context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .Where(a => a.PatientId == patientId)
            .Select(a => new AppointmentDto
            {
                Id = a.Id,
                Booking = a.Booking,
                Doctor = new DoctorDTO { Id = a.Doctor.Id, FullName = a.Doctor.FullName },
                Patient = new PatientDTO { Id = a.Patient.Id, FullName = a.Patient.FullName }
            })
            .ToListAsync();

        return Ok(appointments);
    }

    [HttpPost]
    public async Task<ActionResult<AppointmentDto>> CreateAppointment(CreateAppointmentDto dto)
    {
        var appointment = new Appointment
        {
            Booking = dto.Booking,
            DoctorId = dto.DoctorId,
            PatientId = dto.PatientId
        };

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        appointment = await _context.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .FirstOrDefaultAsync(a => a.Id == appointment.Id);

        var appointmentDto = new AppointmentDto
        {
            Id = appointment.Id,
            Booking = appointment.Booking,
            Doctor = new DoctorDTO { Id = appointment.Doctor.Id, FullName = appointment.Doctor.FullName },
            Patient = new PatientDTO { Id = appointment.Patient.Id, FullName = appointment.Patient.FullName }
        };

        return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, appointmentDto);
    }
}
