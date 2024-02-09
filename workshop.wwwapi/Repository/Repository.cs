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

        public async Task<Patient?> GetPatientById(int id)
        {
            return await _databaseContext.Patients.FindAsync(id);
        }

        public async Task<Patient?> AddPatient(string name)
        {
            if (name == null || name == "") { return null; }
            Patient? patient = new Patient { FullName = name };
            if (patient == null) { return null; }
            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.FindAsync(id);
        }


        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _databaseContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor) // Ensure that the Doctor is loaded
                .Include(a => a.Prescriptions)
                    .ThenInclude(pm => pm.PrescriptionMedicines)
                        .ThenInclude(m => m.Medicine)
                        .ToListAsync();
        }

        public async Task<Appointment?> GetAppointmentWithDetailsById(int appointmentId)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }
        public async Task<List<Appointment>?> GetAppointmentsByDoctorId(int doctorId)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        

    }
}
