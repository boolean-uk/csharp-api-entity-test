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
        public async Task<Patient> GetPatient(int id)
        {
            var patient = await _databaseContext.Patients.FindAsync(id);
            _databaseContext.Entry(patient).Collection(x => x.Appointments).Load();
            return patient;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ToListAsync();
        }

        public async Task<Patient> AddPatient(Patient patient)
        {

            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            var doc = await _databaseContext.Doctors.FindAsync(id);
            _databaseContext.Entry(doc).Collection(x => x.Appointments).Load();
            return doc;
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsById(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }

    }
}
