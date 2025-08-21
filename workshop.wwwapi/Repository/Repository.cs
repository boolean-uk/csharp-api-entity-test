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
        public async Task<IEnumerable<PatientDTO>> GetPatients()
        {
            List<Patient> patients = await _databaseContext.Patients.Include(p => p.Appointments).ToListAsync();
            List<PatientDTO> display_patients = patients.Select(p => ConvertPatient(p).Result).ToList();
            return display_patients;
        }

        public async Task<Patient> GetPatientById(int patientId)
        {
            var response = await _databaseContext.Patients.Where(p => p.Id == patientId).Include(a => a.Appointments).FirstOrDefaultAsync();
            if (response == null) { return null; }
            return response;
        }

        public async Task<PatientDTO> ConvertPatient(Patient patient)
        {
            PatientDTO patientDTO = new PatientDTO()
            {
                Fullname = patient.FullName,
                Appointments = patient.Appointments.Select(a => new AppointmentForPatientDTO
                { DoctorName = GetDoctorById(a.DoctorId).Result.FullName}).ToList()
            };
            return patientDTO;
        }
        public async Task<Patient> CreatePatient(PatientDTO patientDTO)
        {
            Patient patient = new Patient() { Id = _databaseContext.Patients.OrderBy(p => p.Id).Last().Id + 1, FullName = patientDTO.Fullname };
            await _databaseContext.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
        public async Task<DoctorDTO> ConvertDoctor(Doctor doctor)
        {
            DoctorDTO doctorDTO = new DoctorDTO
            {
                Name = doctor.FullName,
                Appointments = doctor.Appointments.Select(a => new AppointmentForDoctorDTO
                { PatientName = GetPatientById(a.PatientId).Result.FullName }).ToList()
            };
            return doctorDTO;
        }

        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            var doctors = await _databaseContext.Doctors.Include(d => d.Appointments).ToListAsync();
            return doctors.Select(d => ConvertDoctor(d).Result);
        }
        public async Task<Doctor> GetDoctorById(int doctorId)
        {
            var response = await _databaseContext.Doctors.Where(d => d.Id == doctorId).Include(a =>  a.Appointments).FirstOrDefaultAsync();
            if (response == null) { return null; }
            return response;
        }
        public async Task<Doctor> CreateDoctor(DoctorDTO doctorDTO)
        {
            Doctor doctor = new Doctor() { FullName = doctorDTO.Name };
            await _databaseContext.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }
        public async Task<Appointment> CreateAppointment(int doctorId, int patientId)
        {
            Appointment appointment = new Appointment() { DoctorId = doctorId, PatientId = patientId , Booking=DateTime.UtcNow};
            await _databaseContext.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }
    }
}
