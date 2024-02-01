using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
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

        public async Task<Patient> GetPatientById(int id)
        {
            Patient patient = await _databaseContext.Patients.FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new ArgumentException($"No patient with id: {id}");
            return patient;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.ToListAsync();
        }

        public async Task<Patient> AddPatient(AddPatientDTO dto) 
        {
            Patient patient = new()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
            await _databaseContext.Patients.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<Doctor> GetDoctorById(int id)
        {
            Doctor doctor = await _databaseContext.Doctors
                .FirstOrDefaultAsync(d => d.Id == id)
                ?? throw new ArgumentException($"No doctor with id: {id}");
            return doctor;
        }

        public async Task<Doctor> AddDoctor(GetDoctorDTO dto)
        {
            Doctor doctor = new()
            {
                Name = dto.Name
            };
            await _databaseContext.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Appointment> AddAppointment(AddAppointmentDTO dto)
        {
            Doctor doctor = await GetDoctorById(dto.DoctorId);
            Patient patient = await GetPatientById(dto.PatientId);
            Appointment appointment = new()
            {
                Doctor = doctor,
                Patient = patient,
                AppointmentDate = dto.AppointmentDate,
            };
            await _databaseContext.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> GetAppointmentById(int patientId, int doctorId)
        {
            Appointment appointment = await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(a => a.PatientId == patientId && a.DoctorId == doctorId)
                ?? throw new ArgumentException($"No appointment with given ids");
            return appointment;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Where(a => a.DoctorId == id)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == id)
                .ToListAsync();
        }
    }
}
