using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private readonly DatabaseContext _db;

        public Repository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _db.Patients
                .Include(patient => patient.Appointments)
                .ThenInclude(appointment => appointment.Doctor)
                .ToListAsync();
        }

        public async Task<Patient?> GetPatient(int id)
        {
            return await _db.Patients
                .Include(patient => patient.Appointments)
                .ThenInclude(appointment => appointment.Doctor)
                .FirstAsync(patient => patient.Id == id);
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            await _db.Patients.AddAsync(patient);
            await _db.SaveChangesAsync();
            return patient;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _db.Doctors
                .Include(doctor => doctor.Appointments)
                .ThenInclude(appointment => appointment.Patient)
                .ToListAsync();
        }

        public async Task<Doctor?> GetDoctor(int id)
        {
            return await _db.Doctors
                .Include(doctor => doctor.Appointments)
                .ThenInclude(appointment => appointment.Patient)
                .FirstAsync(doctor => doctor.Id == id);
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            await _db.Doctors.AddAsync(doctor);
            await _db.SaveChangesAsync();
            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _db.Appointments
                .Include(appointment => appointment.Patient)
                .Include(appointment => appointment.Doctor)
                .ToListAsync();
        }

        public async Task<Appointment?> GetAppointment(int id)
        {
            return await _db.Appointments
                .Include(appointment => appointment.Doctor)
                .Include(appointment => appointment.Patient)
                .FirstAsync(appointment => appointment.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _db.Appointments
                .Where(a => a.DoctorId == id)
                .Include(appointment => appointment.Patient)
                .Include(appointment => appointment.Doctor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _db.Appointments
                .Where(a => a.PatientId == id)
                .Include(appointment => appointment.Patient)
                .Include(appointment => appointment.Doctor)
                .ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            await _db.Appointments.AddAsync(appointment);
            await _db.SaveChangesAsync();
            return appointment;
        }
    }
}