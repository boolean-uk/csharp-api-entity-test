using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;

        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext
                .Patients.Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToListAsync();
        }

        public async Task<Patient?> GetPatient(int id)
        {
            return await _databaseContext
                .Patients.Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext
                .Doctors.Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Doctor?> GetDoctor(int id)
        {
            return await _databaseContext
                .Doctors.Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext
                .Appointments.Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.DoctorId == id)
                .ToListAsync();
        }

        public async Task<Doctor?> CreateDoctor(DoctorPostDto doctor)
        {
            var doc = new Doctor { FullName = doctor.FullName };
            var e = _databaseContext.Add(doc);
            await _databaseContext.SaveChangesAsync();
            return await GetDoctor(e.Entity.Id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext
                .Appointments.Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext
                .Appointments.Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
        }

        public async Task<Appointment?> CreateAppointment(AppointmentPostDto appointment)
        {
            var app = new Appointment
            {
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                Booking = appointment.Booking,
            };
            var entity = _databaseContext.Appointments.Add(app);
            await _databaseContext.SaveChangesAsync();
            return await this.GetAppointment(entity.Entity.Id);
        }

        public async Task<Appointment?> GetAppointment(int id)
        {
            return await _databaseContext
                .Appointments.Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Patient?> CreatePatient(PatientPostDto patient)
        {
            var p = new Patient { FullName = patient.FullName };
            var res = _databaseContext.Patients.Add(p);
            await _databaseContext.SaveChangesAsync();
            return await GetPatient(res.Entity.Id);
        }
    }
}
