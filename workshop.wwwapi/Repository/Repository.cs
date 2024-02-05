using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTO;
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
            var patients = await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).ToListAsync();
            
            _databaseContext.SaveChanges();
            return patients;
        }

        public async Task<Patient> GetPatient(int id)
        {
            var patient = await _databaseContext.Patients.FindAsync(id);
            
            _databaseContext.SaveChanges();
            return patient;
        }

        public async Task<Patient> CreateAPatient(PatientPostPayload patientPayload)
        {
            Patient patient =  new Patient() {FullName = patientPayload.fullName };
            _databaseContext.Patients.Add(patient);
            _databaseContext.SaveChanges();
            return patient;
        }
        

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<Doctor> GetDoctorsByID(int id)
        {
            var doctor = await _databaseContext.Doctors.FindAsync(id);

            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentsByID(int id)
        {
            var appointment = await _databaseContext.Appointments.FindAsync(id);
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==doctorId).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientID(int patientId)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == patientId).ToListAsync();
        }

        public async Task<Appointment?> CreateAppointment(DateTime date, int patientId, int doctorId)
        {
            Appointment appointment = new Appointment();
            appointment.PatientId = patientId;
            appointment.DoctorId = doctorId;
            appointment.appointmentDate = date;

            appointment.Patient = await _databaseContext.Patients.FindAsync(patientId);
            appointment.Doctor = await _databaseContext.Doctors.FindAsync(doctorId);

            if (appointment.Doctor != null || appointment.Patient != null)
            {
                _databaseContext.Appointments.Add(appointment);
                _databaseContext.SaveChanges();
                return appointment;
            }
            else
            {
                return null;
            }

            
        }
    }
}
