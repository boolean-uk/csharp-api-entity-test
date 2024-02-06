using Microsoft.EntityFrameworkCore;
using System.Linq;
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


        //PATIENTS
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a=> a.Doctor)
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        public async Task<Patient?> GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return patient;
        }

        public async Task<Patient> CreatePatient(PatientPost model)
        {
            int newId = _databaseContext.Patients.Any() ? _databaseContext.Patients.Max(p => p.Id) + 1 : 1;

            var patient = new Patient
            {
                Id = newId,
                FullName = model.FullName
            };

            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }


        //DOCTORS
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .OrderBy(d => d.Id)
                .ToListAsync();
        }

        public async Task<Doctor?> GetDoctorById(int id)
        {
            var doctor = await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();
            return doctor;
        }

        public async Task<Doctor> CreateDoctor(DoctorPost model)
        {
            int newId = _databaseContext.Patients.Any() ? _databaseContext.Patients.Max(p => p.Id) + 1 : 1;

            var doctor = new Doctor
            {
                Id = newId,
                FullName = model.FullName
            };

            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }


        //APPOINTMENTS
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId == id)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(AppointmentPost model)
        {
            var doctor = await GetDoctorById(model.DoctorId);
            var patient = await GetPatientById(model.PatientId);

            int newId = _databaseContext.Appointments.Any() ? _databaseContext.Appointments.Max(a => a.Id) + 1 : 1;
            var appointment = new Appointment
            {
                Id = newId,
                DoctorId = model.DoctorId,
                Doctor = doctor,
                PatientId = model.PatientId,
                Patient = patient,
                Booking = model.Booking
            };
            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }
    }
}
