using Microsoft.EntityFrameworkCore;
using System.Data;
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
                .Include(a => a.Prescriptions)
                    .ThenInclude(pm => pm.PrescriptionMedicines)
                        .ThenInclude(m => m.Medicine)
                        .FirstOrDefaultAsync(a => a.Id == appointmentId);
        }
        public async Task<List<Appointment>?> GetAppointmentsByDoctorId(int doctorId)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Prescriptions)
                    .ThenInclude(pm => pm.PrescriptionMedicines)
                        .ThenInclude(m => m.Medicine)
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<Appointment?> assignAppointment(int patient_id, int doc_id, AppointmentType appointmentType)
        {
            var patient = await GetPatientById(patient_id);
            if (patient == null)
            {
                return null;
            }
            var doctor = await GetDoctorById(doc_id);   
            if (doctor == null)
            {
                return null;
            }

            var newAppointment = new Appointment
            {
                PatientId = patient_id,
                DoctorId = doctor.Id,
                Booking = DateTime.UtcNow.ToString(),
                TypeOfAppointent = appointmentType
            };

            _databaseContext.Appointments.Add(newAppointment);
            await _databaseContext.SaveChangesAsync();

            return newAppointment;  
        }
    }
}
