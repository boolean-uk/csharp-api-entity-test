using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }

        //------------ Patient ------------------------
        public async Task<IEnumerable<PatientDTO>> GetPatients()
        {
            var patients = await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToListAsync();

            var patientDTOs = patients.Select(p => new PatientDTO
            {
                Id = p.Id,
                FullName = p.FullName,
                Appointments = p.Appointments.Select(a => new DoctorAppointmentDTO
                {
                    Booking = a.Booking,
                    DoctorId = a.DoctorId,
                    DoctorFullName = a.Doctor.FullName
                }).ToList()
            });
            return patientDTOs;
        }

        public async Task<PatientDTO> GetPatientbyId(int id)
        {
            var patient = await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return null;
            }

            var patientDTO = new PatientDTO
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = patient.Appointments.Select(a => new DoctorAppointmentDTO
                {
                    Booking = a.Booking,
                    DoctorId = a.DoctorId,
                    DoctorFullName = a.Doctor.FullName
                }).ToList()
            };
            return patientDTO;
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }

        //------------- Doctor ------------------
        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            var doctors = await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .ToListAsync();

            var doctorDTOs = doctors.Select(d => new DoctorDTO
            {
                Id = d.Id,
                FullName = d.FullName,
                Appointments = d.Appointments.Select(a => new PatientAppointmentDTO
                {
                    Booking = a.Booking,
                    PatientId = a.PatientId,
                    PatientFullName = a.Patient.FullName
                }).ToList()
            });
            return doctorDTOs;
        }

        public async Task<DoctorDTO> GetDoctorById(int id)
        {
            var doctor = await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (doctor == null)
            {
                return null;
            }

            var doctorDTO = new DoctorDTO
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Appointments = doctor.Appointments.Select(a => new PatientAppointmentDTO
                {
                    Booking = a.Booking,
                    PatientId = a.PatientId,
                    PatientFullName = a.Patient.FullName
                }).ToList()
            };
            return doctorDTO;
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }

        //-------------- Appointment -------------------
        public async Task<IEnumerable<AppointmentDTO>> GetAppointments()
        {
            var appointments = await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescriptions)
                .ToListAsync();

            var appointmentDTOs = appointments.Select(a => new AppointmentDTO
            {
                Booking = a.Booking,
                DoctorId = a.DoctorId,
                DoctorFullName = a.Doctor.FullName,
                PatientId = a.PatientId,
                PatientFullName = a.Patient.FullName,
                Prescriptions = a.Prescriptions.Select(p => new PrescriptionDTOLess { Id = p.Id }).ToList()
            });

            return appointmentDTOs;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id)
        {
            var appointments = await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescriptions)
                .Where(a => a.DoctorId == id)
                .ToListAsync();

            var appointmentDTOs = appointments.Select(a => new AppointmentDTO
            {
                Booking = a.Booking,
                DoctorId = a.DoctorId,
                DoctorFullName = a.Doctor.FullName,
                PatientId = a.PatientId,
                PatientFullName = a.Patient.FullName,
                Prescriptions = a.Prescriptions.Select(p => new PrescriptionDTOLess { Id = p.Id }).ToList()
            });

            return appointmentDTOs;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(int id)
        {
            var appointments = await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescriptions)
                .Where(a => a.PatientId == id)
                .ToListAsync();

            var appointmentDTOs = appointments.Select(a => new AppointmentDTO
            {
                Booking = a.Booking,
                DoctorId = a.DoctorId,
                DoctorFullName = a.Doctor.FullName,
                PatientId = a.PatientId,
                PatientFullName = a.Patient.FullName,
                Prescriptions = a.Prescriptions.Select(p => new PrescriptionDTOLess { Id = p.Id }).ToList()
            });

            return appointmentDTOs;
        }

        //-------------------------- Medicine & Prescription -----------------------------
        public async Task<IEnumerable<MedicineDTO>> GetAllMedicines()
        {
            var medicines = await _databaseContext.Medicines
                .Include(m => m.Prescriptions)
                .Select(m => new MedicineDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Quantity = m.Quantity,
                    Instructions = m.Instructions,
                    Prescriptions = m.Prescriptions.Select(p => new PrescriptionDTOLess
                    {
                        Id = p.Id
                    }).ToList()
                }).ToListAsync();

            return medicines;
        }

        public async Task<IEnumerable<PrescriptionDTO>> GetAllPrescriptions()
        {
            var prescriptions = await _databaseContext.Prescriptions
                .Include(p => p.Medicines)
                .Select(p => new PrescriptionDTO
                {
                    Id = p.Id,
                    Medicines = p.Medicines.Select(m => new MedicineDTOLess
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Quantity = m.Quantity,
                        Instructions = m.Instructions
                    }).ToList()
                }).ToListAsync();

            return prescriptions;
        }

        public async Task<Prescription> CreatePrescription(Prescription prescription)
        {
            _databaseContext.Prescriptions.Add(prescription);
            await _databaseContext.SaveChangesAsync(); 
            return prescription;
        }

        public async Task<PrescriptionDTO> AddMedicineToPrescription(int medicineId, int prescriptionId)
        {
            var medicine = await _databaseContext.Medicines.FindAsync(medicineId);
            var prescription = await _databaseContext.Prescriptions.FindAsync(prescriptionId);

            if (medicine == null || prescription == null)
                return null;

            prescription.Medicines.Add(medicine);
            await _databaseContext.SaveChangesAsync();

            var updatedPrescription = await _databaseContext.Prescriptions
                .Include(p => p.Medicines)
                .Where(p => p.Id == prescriptionId)
                .Select(p => new PrescriptionDTO
                {
                    Id = p.Id,
                    Medicines = p.Medicines.Select(m => new MedicineDTOLess
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Quantity = m.Quantity,
                        Instructions = m.Instructions
                    }).ToList()
                }).FirstOrDefaultAsync();

            return updatedPrescription;
        }

        public async Task<AppointmentDTO> AddPrescriptionToAppointment(int doctorId, int patientId, int prescriptionId)
        {
            var appointment = await _databaseContext.Appointments
                .Include(a => a.Prescriptions)
                .FirstOrDefaultAsync(a => a.DoctorId == doctorId && a.PatientId == patientId);

            var prescription = await _databaseContext.Prescriptions.FindAsync(prescriptionId);

            if (appointment == null || prescription == null)
                return null;

            appointment.Prescriptions.Add(prescription);
            await _databaseContext.SaveChangesAsync();

            var updatedAppointment = await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescriptions)
                .FirstOrDefaultAsync(a => a.DoctorId == doctorId && a.PatientId == patientId);

            if (updatedAppointment == null)
                return null;

            var appointmentDTO = new AppointmentDTO
            {
                Booking = updatedAppointment.Booking,
                DoctorId = updatedAppointment.DoctorId,
                DoctorFullName = updatedAppointment.Doctor.FullName,
                PatientId = updatedAppointment.PatientId,
                PatientFullName = updatedAppointment.Patient.FullName,
                Prescriptions = updatedAppointment.Prescriptions
                    .Select(p => new PrescriptionDTOLess { Id = p.Id }).ToList()
            };

            return appointmentDTO;
        }
    }
}
