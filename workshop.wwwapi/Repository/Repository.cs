using Microsoft.EntityFrameworkCore;
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
            return await _databaseContext.Patients.ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id).ToListAsync();
        }
        public async Task<Appointment> CreateAppointment(int doctorid, int patientid)
        {
            Appointment appointment = new Appointment();
            appointment.DoctorId = doctorid;
            appointment.PatientId = patientid;
            appointment.Booking = new DateTime();

            await _databaseContext.Appointments.AddAsync(appointment);

            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }



        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            await _databaseContext.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            await _databaseContext.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }
    }
}
