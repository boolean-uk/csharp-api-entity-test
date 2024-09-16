//TODO: IN FREE TIME REFRACTOR CODE AND ORGANIZE IT INTO SEPARETE FILES!!!


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
        public async Task<PatientDto> GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(patient == null)
            {
                return null;
            }

            var patientDto = new PatientDto
            {
                FullName = patient.FullName ,
                Appointments = patient.Appointments.Select(a => new AppointmentDto
                {
                    Booking = a.Booking ,
                    DoctorId = a.DoctorId ,
                    DoctorName = a.Doctor.FullName ,
                    PatientId = a.PatientId ,
                    PatientName = patient.FullName
                }).ToList()
            };

            return patientDto;
        }
        public async Task<Patient> CreatePatient(PatientDto patientDto)
        {
            var patient = new Patient
            {
                FullName = patientDto.FullName
            };
            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId == id).ToListAsync();
        }
        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.FindAsync(id);
        }

        public async Task<Doctor> CreateDoctor(DoctorDto doctorDto)
        {
            var doctor = new Doctor
            {
                FullName = doctorDto.FullName
            };
            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int patientId , int doctorId)
        {
            return await _databaseContext.Appointments.FindAsync(patientId , doctorId);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(AppointmentDto appointmentDto)
        {
            var existingAppointment = await _databaseContext.Appointments
                .FirstOrDefaultAsync(a => a.PatientId == appointmentDto.PatientId && a.DoctorId == appointmentDto.DoctorId);

            if(existingAppointment != null)
            {
                throw new Exception("An appointment with this patient and doctor already exists.");
            }

            var appointment = new Appointment
            {
                Booking = appointmentDto.Booking ,
                DoctorId = appointmentDto.DoctorId ,
                PatientId = appointmentDto.PatientId
            };

            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();

            return appointment;
        }
        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await _databaseContext.Medicines.ToListAsync();
        }

        public async Task<Medicine> GetMedicineById(int id)
        {
            return await _databaseContext.Medicines.FindAsync(id);
        }

        public async Task<Medicine> CreateMedicine(Medicine medicine)
        {
            _databaseContext.Medicines.Add(medicine);
            await _databaseContext.SaveChangesAsync();
            return medicine;
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.ToListAsync();
        }

        public async Task<Prescription> GetPrescriptionById(int id)
        {
            return await _databaseContext.Prescriptions.FindAsync(id);
        }

        public async Task<Prescription> CreatePrescription(Prescription prescription)
        {
            _databaseContext.Prescriptions.Add(prescription);
            await _databaseContext.SaveChangesAsync();
            return prescription;
        }

        public async Task<Prescription> AttachMedicineToPrescription(int prescriptionId , int medicineId , int quantity , string notes)
        {
            var prescription = await _databaseContext.Prescriptions.FindAsync(prescriptionId);
            var medicine = await _databaseContext.Medicines.FindAsync(medicineId);
            if(prescription == null || medicine == null)
            {
                throw new Exception("Prescription or Medicine not found.");
            }
            var prescriptionMedicine = new PrescriptionMedicine
            {
                PrescriptionId = prescriptionId ,
                MedicineId = medicineId ,
                Quantity = quantity ,
                Notes = notes
            };
            _databaseContext.PrescriptionsMedicines.Add(prescriptionMedicine);
            await _databaseContext.SaveChangesAsync();
            return prescription;
        }
    }
}
