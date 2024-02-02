using Microsoft.EntityFrameworkCore;
using System.IO;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.InputObject;

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
            return await _databaseContext.Patients.Include(p=>p.Appointments).ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(p => p.Appointments).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).FirstOrDefaultAsync(a=>a.Id==id);
        }

        public async Task<Patient> CreatePatient(string fullname)
        {
            Patient patient = new Patient()
            {
                Id = _databaseContext.Patients.Max(p => p.Id) + 1,
                FullName = fullname
            };
            _databaseContext.Patients.Add(patient);
            _databaseContext.SaveChanges();
            return await GetPatientById(patient.Id);
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Include(p => p.Appointments).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Doctor> CreateDoctor(string fullname)
        {
            Doctor doctor = new Doctor()
            {
                Id = _databaseContext.Doctors.Max(p => p.Id) + 1,
                FullName = fullname
            };
            _databaseContext.Doctors.Add(doctor);
            _databaseContext.SaveChanges();
            return await GetDoctorById(doctor.Id);
        }
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();

        }
        public async Task<Appointment> GetAppointmentByIDs(int DocId, int PatId)
        {
            return await _databaseContext.Appointments.FirstOrDefaultAsync(a => a.DoctorId == DocId && a.PatientId == PatId);
        }

        public async Task<Appointment> CreateAppointment(InputAppointment input)
        {
            Appointment appointment = new Appointment()
            {
                Booking = input.Booking,
                DoctorId = input.DoctorId,
                PatientId = input.PatientId
            };
            _databaseContext.Appointments.Add(appointment);
            _databaseContext.SaveChanges();
            return await GetAppointmentByIDs(appointment.DoctorId,appointment.PatientId);
        }

        
    }
}
