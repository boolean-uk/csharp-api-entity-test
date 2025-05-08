using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
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
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).ToListAsync();
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<Patient> AddPatient(string name)
        {
            Patient p = new Patient() { FullName = name };
            await _databaseContext.Patients.AddAsync(p);
            await _databaseContext.SaveChangesAsync();
            return p;
        }


        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).ToListAsync();
        }
        public async Task<Doctor> GetDoctor(int id)
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Doctor> AddDoctor(string name)
        {
            Doctor d = new Doctor() { FullName = name };
            await _databaseContext.Doctors.AddAsync(d);
            await _databaseContext.SaveChangesAsync();
            return d;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<Appointment> AddAppointment(Appointment a)
        {
            if (_databaseContext.Doctors.Any(d => d.Id == a.DoctorId) && _databaseContext.Patients.Any(p => p.Id == a.PatientId))
            {
                a.Booking = DateTime.UtcNow;
                await _databaseContext.Appointments.AddAsync(a);
                await _databaseContext.SaveChangesAsync();
                return _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefault(x => x.PatientId == a.PatientId && x.DoctorId == a.DoctorId);
            }
            return null;
        }
    }
}
