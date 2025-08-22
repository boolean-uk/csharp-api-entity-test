using Microsoft.EntityFrameworkCore;
using System.Numerics;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
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
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor) 
                .ToListAsync();
        }
        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Patient> CreatePatient(PatientPost patient)
        {
           Patient p = new Patient();
           p.FullName = patient.FullName;
           var newpatient = await _databaseContext.Patients.AddAsync(p);
            await _databaseContext.SaveChangesAsync();
           return newpatient.Entity;

        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Include(a => a.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Doctor> CreateDoctor(DoctorPost doctor)
        {
            Doctor d = new();
            d.FullName = doctor.FullName;
            var newdoctor = await _databaseContext.Doctors.AddAsync(d);
            await _databaseContext.SaveChangesAsync();
            return newdoctor.Entity;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).ToListAsync(); 
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorid)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorID == doctorid).Include(a => a.Patient).Include(a => a.Doctor).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int patientid)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientID == patientid).Include(a => a.Patient).Include(a => a.Doctor).ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(AppointmentPost appointment)
        {
            Appointment a = new();
            a.PatientID = appointment.PatientID;
            a.DoctorID = appointment.DoctorID;
            a.Booking = appointment.Booking;
            var newappointment = await _databaseContext.Appointments.AddAsync(a);
            await _databaseContext.SaveChangesAsync();

            int id = newappointment.Entity.Id;
            var loadedAppointment = await _databaseContext.Appointments
                    .Include(ap => ap.Doctor)
                    .Include(ap => ap.Patient)
                    .FirstOrDefaultAsync(ap => ap.Id == id);

            return loadedAppointment!;

        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.Include(a => a.Medicine).Include(a => a.Appointment).ThenInclude(a => a.Doctor).Include(a => a.Appointment).ThenInclude(a => a.Patient).ToListAsync();
        }
    }
}
