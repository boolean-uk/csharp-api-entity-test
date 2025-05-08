using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {

        private DatabaseContext _db;

        public Repository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _db.Patients.Include(p => p.Appointments).ToListAsync();
        }


        public async Task<Patient> GetPatient(int id)
        {
            return await _db.Patients.Include(p => p.Appointments).FirstOrDefaultAsync(a => a.Id == id);
        }


        public async Task<Patient> CreatePatient(Patient patient)
        {
            await _db.AddAsync(patient);
            await _db.SaveChangesAsync();
            return patient;

        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _db.Doctors.Include(d => d.Appointments).ToListAsync();
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await _db.Doctors.Include(d => d.Appointments).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            await _db.AddAsync(doctor);
            await _db.SaveChangesAsync();
            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _db.Appointments.ToListAsync();
        }


        public async Task<Appointment> GetAppointmentById(int patientId, int doctorId)
        {
            var appointments = await _db.Appointments
                .Where(a => a.PatientId == patientId && a.DoctorId == doctorId)
                .FirstOrDefaultAsync();
            return appointments;
        }


        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _db.Appointments.Where(a => a.DoctorId==id).ToListAsync(); 
        }


        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _db.Appointments.Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            await _db.AddAsync(appointment);
            await _db.SaveChangesAsync();
            return appointment;
        }

    }
}

