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
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments
                  .Include(a => a.Doctor)
                  .Include(a => a.Patient)
                  .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id)
        {
            var appointments = await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Where(a => a.DoctorId == id)
                .Select(a => new AppointmentDTO
                {
                    Booking = a.Booking,
                    DoctorId = a.DoctorId,
                    DoctorFullName = a.Doctor.FullName,
                    PatientId = a.PatientId,
                    PatientFullName = a.Patient.FullName
                })
                .ToListAsync();
            return appointments;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(int id)
        {
            var appointments = await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Where(a => a.PatientId == id)
                .Select(a => new AppointmentDTO
                {
                    Booking = a.Booking,
                    DoctorId = a.DoctorId,
                    DoctorFullName = a.Doctor.FullName,
                    PatientId = a.PatientId,
                    PatientFullName = a.Patient.FullName
                })
                .ToListAsync();
            return appointments; 
        }
    }
}
