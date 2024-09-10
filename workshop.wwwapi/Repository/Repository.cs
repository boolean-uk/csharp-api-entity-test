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
            return await _databaseContext.Patients.ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Include(a => a.Appointments).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient> AddPatient(int id, string name)
        {
 
            await _databaseContext.Patients.AddAsync(new() { Id = id, FullName = name, Appointments = new List<Appointment>() });
            await _databaseContext.SaveChangesAsync();   
            return new Patient {Id =id, FullName = name};
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Include(a => a.Appointments).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Doctor> AddDoctor(int id, string name)
        {
            await _databaseContext.Doctors.AddAsync(new() { Id = id, FullName = name, Appointments = new List<Appointment>() });
            await _databaseContext.SaveChangesAsync();
            return new Doctor { Id = id, FullName = name };
        }

        public async Task<Appointment> AddAppointment(int doctorId, int patientId, DateTime dateTime)
        {
            Appointment appointment = new(){ Booking = dateTime, DoctorId = doctorId, PatientId = patientId };
            Patient patient = await _databaseContext.Patients.FindAsync(patientId);
            patient.Appointments.Add(appointment);
            Doctor doctor = await _databaseContext.Doctors.FindAsync(doctorId);
            doctor.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id).ToListAsync();
        }
    }
}
