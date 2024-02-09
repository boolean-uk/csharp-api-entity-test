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
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(d => d.Doctor).ToListAsync();
        }

        public async Task<Patient?> GetPatientById(int id, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(d => d.Doctor).FirstOrDefaultAsync(p => p.Id == id);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _databaseContext.Patients.FirstOrDefaultAsync(p => p.Id == id);  
                default:
                    return null;
            }
        }

        public async Task<Patient?> CreatePatient(string fullName)
        {   
            if (string.IsNullOrEmpty(fullName))
            {
                return null;
            }
            var patient = new Patient
            {
                FullName = fullName
            };
            await _databaseContext.Patients.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(p => p.Patient).ToListAsync();
        }

        public async Task<Doctor?> GetDoctorById(int id, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(p => p.Patient).FirstOrDefaultAsync(d => d.Id == id);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _databaseContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);
                default:
                    return null;
            }
        }

        public async Task<Doctor?> CreateDoctor(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                return null;
            }
            var doctor = new Doctor
            {
                FullName = fullName
            };
            await _databaseContext.Doctors.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Prescription).ToListAsync();
        }

        public async Task<Appointment?> CreateAppointment(DateTime booking, Doctor doctor, Patient patient, Prescription prescription, string type)
        {
            if (doctor == null || patient == null || prescription == null || string.IsNullOrEmpty(type))
            {
                return null;
            }
            var appointment = new Appointment
            {
                Booking = booking,
                DoctorId = doctor.Id,
                PatientId = patient.Id,
                PrescriptionId = prescription.Id,
                Type = type
            };
            await _databaseContext.Appointments.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }   
    

        public async Task<Appointment?> GetAppointmentByPatientId(int patientId)
        {
            return await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).Include(p => p.Prescription).FirstOrDefaultAsync(a => a.PatientId == patientId);
        }

        public async Task<Appointment?> GetAppointmentByDoctorId(int doctorId)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(p => p.Prescription).FirstOrDefaultAsync(a => a.DoctorId == doctorId);
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.Include(p => p.MedicinePrescriptions).ThenInclude(m => m.Medicine).ToListAsync();
        }

        public async Task<Prescription?> GetPrescriptionById(int id, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _databaseContext.Prescriptions.Include(p => p.MedicinePrescriptions).ThenInclude(m => m.Medicine).FirstOrDefaultAsync(p => p.Id == id);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _databaseContext.Prescriptions.FirstOrDefaultAsync(p => p.Id == id);
                default:
                    return null;
            }
        }      

        public async Task<Prescription?> CreatePrescription(int medicineId, int quantity, string notes)
        {
            if (string.IsNullOrEmpty(notes) || quantity <= 0)
            {
                return null;
            }
            var prescription = new Prescription
            {
                Quantity = quantity,
                Notes = notes
            };
            await _databaseContext.Prescriptions.AddAsync(prescription);
            await _databaseContext.SaveChangesAsync();
            var medicinePrescription = new MedicinePrescription
            {
                MedicineId = medicineId,
                PrescriptionId = prescription.Id
            };
            await _databaseContext.MedicinePrescriptions.AddAsync(medicinePrescription);
            await _databaseContext.SaveChangesAsync();
            return prescription;
        }

        public async Task<Appointment?> LinkPrescriptionToAppointment(int doctorId, int patientId, int prescriptionId)
        {       
            if (doctorId <= 0 || patientId <= 0 || prescriptionId <= 0)
            {
                return null;
            }
            var prescription = await _databaseContext.Prescriptions.Include(m => m.MedicinePrescriptions).ThenInclude(m => m.Medicine).FirstOrDefaultAsync(p => p.Id == prescriptionId);
            var appointment = await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(p => p.PatientId == patientId).FirstOrDefaultAsync(a => a.DoctorId == doctorId);
            if (appointment == null || prescription == null)
            {
                return null;
            }
            appointment.Prescription = prescription;
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await _databaseContext.Medicines.Include(m => m.MedicinePrescriptions).ThenInclude(p => p.Prescription).ToListAsync();
        }

        public async Task<Medicine?> GetMedicineById(int id, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _databaseContext.Medicines.Include(m => m.MedicinePrescriptions).ThenInclude(p => p.Prescription).FirstOrDefaultAsync(m => m.Id == id);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _databaseContext.Medicines.FirstOrDefaultAsync(m => m.Id == id);
                default:
                    return null;
            }
        }

        public async Task<Medicine?> CreateMedicine(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            var medicine = new Medicine
            {
                Name = name
            };
            await _databaseContext.Medicines.AddAsync(medicine);
            await _databaseContext.SaveChangesAsync();
            return medicine;
        }
    }
}
