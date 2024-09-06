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
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id).ToListAsync();
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
            return await _databaseContext.Appointments.OrderByDescending(a=>a.Booking).FirstOrDefaultAsync(a => a.DoctorId == DocId && a.PatientId == PatId);
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

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Presciptions.Include(p => p.Medicines).ToListAsync();
        }

        public async Task<Prescription> GetPrescriptionById(int id)
        {
            return await _databaseContext.Presciptions.Include(p => p.Medicines).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<Prescription> CreatePrescription(IEnumerable<InputPrescription> medicines)
        {
            Prescription prescription = new Prescription() { Id = _databaseContext.Presciptions.Max(p => p.Id) + 1 };
            foreach (var m in medicines)
            {
                MedicinePrescription mp = new MedicinePrescription()
                {
                    PrescriptionId = prescription.Id,
                    MedicineId = m.MedicineId,
                    Quantity = m.Quantity,
                    Notes = m.Notes
                };
                _databaseContext.Add(mp);
                _databaseContext.SaveChangesAsync();
            }
            _databaseContext.Add(prescription);
            _databaseContext.SaveChangesAsync();
            return await GetPrescriptionById(prescription.Id);
        }

        public async Task<Appointment> AddPrescriptionToAppointment(int presID, int DocId, int PatId)
        {
            Appointment ap = await GetAppointmentByIDs(DocId, PatId);
            if (ap == null) return null;
            ap.PrescriptionId = presID;
            return ap;
        }

        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await _databaseContext.Medicines.ToListAsync();
        }

        public async Task<Medicine> GetMedicineById(int id)
        {
            return await _databaseContext.Medicines.FirstOrDefaultAsync(m=>m.Id == id);
        }

        public Task<Medicine> CreateMedicine(string name)
        {
            Medicine medicine = new Medicine()
            {
                Id = _databaseContext.Medicines.Max(m => m.Id) + 1,
                Name = name
            };
            return GetMedicineById(medicine.Id);
        }
    }
}
