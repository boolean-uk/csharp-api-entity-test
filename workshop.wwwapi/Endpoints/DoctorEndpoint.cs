using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;


[ApiController]
//Should be named DoctorController but i decided to keep it like this for now
//since it works
[Route("api/[controller]")]
public class DoctorEndpoint : ControllerBase
{
    private readonly DatabaseContext _context;

    public DoctorEndpoint (DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetAllDoctors()
    {
        var doctors = await _context.Doctors
            .Select(p => new DoctorDTO
            {
                Id = p.Id,
                FullName = p.FullName,
            })
            .ToListAsync();

        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDTO>> GetDoctorById(int id)
    {
        var doctor = await _context.Doctors
            .Where(p => p.Id == id)
            .Select(p => new DoctorDTO
            {
                Id = p.Id,
                FullName = p.FullName,
            })
            .FirstOrDefaultAsync();

        if (doctor == null)
            return NotFound();

        return Ok(doctor);
    }

    [HttpPost]
    public async Task<ActionResult<DoctorDTO>> CreateDoctor(CreateDoctorDTO dto)
    {
        var doctor = new Doctor
        {
            FullName = dto.FullName,
        };

        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();

        var doctorDto = new DoctorDTO
        {
            Id = doctor.Id,
            FullName = doctor.FullName,
        };

        return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctorDto);
    }
}
