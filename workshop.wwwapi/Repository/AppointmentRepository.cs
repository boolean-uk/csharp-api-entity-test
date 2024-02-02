using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs.Appointments;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private DatabaseContext _databaseContext;
        public AppointmentRepository(DatabaseContext db)
        {
            _databaseContext = db;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Appointment> AddAppointment(AddAppointmentDTO dto)
        {
            Doctor doctor = await _databaseContext.Doctors
                .FirstOrDefaultAsync(d => d.Id == dto.DoctorId)
                ?? throw new ArgumentException($"No doctor with id: {dto.DoctorId}");
            Patient patient = await _databaseContext.Patients
                .FirstOrDefaultAsync(p => p.Id == dto.PatientId)
                ?? throw new ArgumentException($"No patient with id: {dto.PatientId}");
            Appointment appointment = new()
            {
                Doctor = doctor,
                Patient = patient,
                AppointmentDate = dto.AppointmentDate,
            };
            await _databaseContext.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> GetAppointmentById(int patientId, int doctorId)
        {
            Appointment appointment = await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(a => a.PatientId == patientId && a.DoctorId == doctorId)
                ?? throw new ArgumentException($"No appointment with given ids");
            return appointment;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Where(a => a.DoctorId == id)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == id)
                .ToListAsync();
        }
    }
}
