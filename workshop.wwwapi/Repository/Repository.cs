using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository(DatabaseContext db) : IRepository
    {
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await db.Patients
                .Include(p => p.Appointments)
                .ThenInclude(p => p.Doctor)
                .ToListAsync();
        }

        public async Task<Patient> GetPatient(int id)
        {
            return (await db.Patients
                .Include(p => p.Appointments)
                .ThenInclude(p => p.Doctor)
                .FirstOrDefaultAsync(x => x.Id == id))!;
        }

        public async Task<Patient> AddPatient(string fullName)
        {
            var p = new Patient() { FullName = fullName };
            await db.Patients.AddAsync(p);
            return p;
        }
        
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await db.Doctors
                .Include(p => p.Appointments)
                .ThenInclude(p => p.Patient)
                .ToListAsync();
        }
        
        public async Task<Doctor> GetDoctor(int id)
        {
            return (await db.Doctors
                .Include(x => x.Appointments)
                .ThenInclude(p => p.Patient)
                .FirstOrDefaultAsync(x => x.Id == id))!;
        }

        public async Task<Doctor> AddDoctor(string fullName)
        {
            var d = new Doctor() { FullName = fullName };
            await db.Doctors.AddAsync(d);
            return d;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await db.Appointments
                .Include(p => p.Patient)
                .Where(a => a.DoctorId==id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await db.Appointments
                .Include(p => p.Doctor)
                .Where(a => a.PatientId==id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await db.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .ToListAsync();
        }

        public async Task<Appointment> GetAppointment(int patientId, int doctorId)
        {
            return await db.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .Where(a => a.PatientId == patientId && a.DoctorId == doctorId)
                .FirstOrDefaultAsync();
        }
        
        public async Task<Appointment> AddAppointment(int patientId, int doctorId, DateTime booking)
        {
            var result = new Appointment() { PatientId = patientId, DoctorId = doctorId, Booking = booking };
            await db.Appointments.AddAsync(result);
            await db.SaveChangesAsync();
            return result;
        }
    }
}
