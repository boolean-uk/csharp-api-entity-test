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

            
            return patients;
        }

        public async Task<Patient?> GetPatient(int id)
        {
            var patient = await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == id);

            
            return patient;
        }

        public async Task<Patient> CreateAPatient(string fullname)
        {
            Patient patient =  new Patient() {FullName = fullname };
            _databaseContext.Patients.Add(patient);
            _databaseContext.SaveChanges();
            return patient;
        }
        

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).ToListAsync();
            return doctors;
        }
        public async Task<Doctor?> GetDoctorsByID(int id)
        {
            var doctor = await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(d => d.Id == id);

            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            var appointment = await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
            return appointment;
        }

        public async Task<Appointment?> GetAppointmentsByID(int doctorID, int patientID)
        {
            
            var appointment = await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefaultAsync(a => a.PatientId == patientID && a.DoctorId == doctorID);
            return appointment;
        }

        public async Task<IEnumerable<Appointment?>> GetAppointmentsByDoctorID(int doctorId)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.DoctorId==doctorId).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientID(int patientId)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.PatientId == patientId).ToListAsync();
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
