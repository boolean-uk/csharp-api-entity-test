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
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).ToListAsync();
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).ToListAsync();
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }

        public async Task<Appointment> GetAppointment(int doctorId, int patientId)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefaultAsync(a => a.DoctorId == doctorId && a.PatientId == patientId);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(AppointmentCreateDto appointmentCreateDto)
        {
            Appointment appointment = new Appointment
            {
                DoctorId = appointmentCreateDto.DoctorId,
                PatientId = appointmentCreateDto.PatientId,
                AppointmentDate = appointmentCreateDto.Time,
                Type = appointmentCreateDto.Type
            };

            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<bool> PatientExists(int id)
        {
            return await _databaseContext.Patients.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> DoctorExists(int id)
        {
            return await _databaseContext.Doctors.AnyAsync(d => d.Id == id);
        }

        public async Task<bool> AppointmentExists(int doctorId, int patientId)
        {
            return await _databaseContext.Appointments.AnyAsync(a => a.DoctorId == doctorId && a.PatientId == patientId);
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.Include(p => p.MedicinePrescriptions).ThenInclude(mp => mp.Medicine)
                .Include(p => p.Appointment).ThenInclude(a => a.Doctor)
                .Include(p => p.Appointment).ThenInclude(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Prescription> GetPrescription(int id)
        {
            return await _databaseContext.Prescriptions.Include(p => p.MedicinePrescriptions).ThenInclude(mp => mp.Medicine)
                .Include(p => p.Appointment).ThenInclude(a => a.Doctor)
                .Include(p => p.Appointment).ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Prescription> CreatePrescription(int doctorId, int patientId)
        {
            Prescription newPrescription = new () { AppointmentPatientId = patientId, AppointmentDoctorId = doctorId };
            _databaseContext.Prescriptions.Add(newPrescription);

            Appointment appointment = new ()
            {
                DoctorId = doctorId,
                PatientId = patientId,
                AppointmentDate = DateTime.Now,
            };

            await _databaseContext.SaveChangesAsync();
            return newPrescription;
        }

        public async Task<bool> MedicineExists(int id)
        {
            return await _databaseContext.Medicines.AnyAsync(m => m.Id == id);
        }

        public async Task<MedicinePrescription> CreateMedicinePrescription(MedicinePrescription medicinePrescription)
        {
            _databaseContext.MedicinePrescriptions.Add(medicinePrescription);
            await _databaseContext.SaveChangesAsync();
            return medicinePrescription;
        }
    }
}
