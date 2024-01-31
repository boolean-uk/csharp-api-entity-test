using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOS;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }

        public async Task<IEnumerable<DoctorBaseDTO>> GetDoctors()
        {
            return await _databaseContext.Doctors
                .Select(doctor => new DoctorBaseDTO(doctor))
                .ToListAsync();
        }

        public async Task<DoctorBaseDTO?> GetDoctorById(int id)
        {
            var doctor = await _databaseContext.Doctors.FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (doctor == null) { return null; }
            return new DoctorBaseDTO(doctor);
        }

        public async Task<Doctor?> AddDoctor(string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname)) { return null; }

            var newDoctor = await _databaseContext.Doctors.AddAsync(new Doctor { FullName = fullname });

            if (newDoctor.State != EntityState.Added) { return null; }
            await _databaseContext.SaveChangesAsync();

            return newDoctor.Entity;
        }


        public async Task<PatientBaseDTO?> GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients.FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (patient == null) { return null; }
            return new PatientBaseDTO(patient);
        }
        public async Task<IEnumerable<PatientBaseDTO>> GetPatients()
        {
            return await _databaseContext.Patients
                .Select(patient => new PatientBaseDTO(patient))
                .ToListAsync();
        }

        public async Task<Patient?> AddPatient(string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname)) { return null; }

            var newPatient = await _databaseContext.Patients.AddAsync(new Patient { FullName = fullname });

            if (newPatient.State != EntityState.Added) { return null; }

            await _databaseContext.SaveChangesAsync();

            return newPatient.Entity;
        }

        public async Task<AppointmentFullDTO?> GetAppointmentById(int doctorId, int patientId)
        {

            var appointment = _databaseContext.Appointments
                .Where(a => a.DoctorId.Equals(doctorId) && a.PatientId.Equals(patientId))
                .FirstOrDefault();

            if (appointment == null)
            {
                return null;
            }

            var doctor = await GetDoctorById(doctorId);
            var patient = await GetPatientById(patientId);

            return new AppointmentFullDTO(appointment, doctor, patient);
        }
        public async Task<IEnumerable<AppointmentDoctorDTO?>> GetAppointmentsByPatient(int id)
        {
            var appointments = await _databaseContext.Appointments
                .Where(a => a.PatientId == id)
                .ToListAsync();

            var appointmentDTOs = new List<AppointmentDoctorDTO>();

            foreach (var appointment in appointments)
            {
                var doctor = await GetDoctorById(appointment.DoctorId);
                appointmentDTOs.Add(new AppointmentDoctorDTO(appointment, doctor));
            }

            return appointmentDTOs;
        }
        public async Task<IEnumerable<AppointmentPatientDTO?>> GetAppointmentsByDoctor(int id)
        {
            var appointments = await _databaseContext.Appointments
                .Where(a => a.DoctorId == id)
                .ToListAsync();

            var appointmentDTOs = new List<AppointmentPatientDTO>();

            foreach (var appointment in appointments)
            {
                var patient = await GetPatientById(appointment.PatientId);
                appointmentDTOs.Add(new AppointmentPatientDTO(appointment, patient));
            }

            return appointmentDTOs;
        }

        public async Task<IEnumerable<AppointmentFullDTO?>> GetAppointments()
        {
            var appointments = await _databaseContext.Appointments.ToListAsync();
            if (appointments.Count == 0) { return null; }

            var resultAppointments = new List<AppointmentFullDTO>();
            foreach (var appointment in appointments)
            {
                var doctor = await GetDoctorById(appointment.DoctorId);
                var patient = await GetPatientById(appointment.PatientId);
                resultAppointments.Add(new AppointmentFullDTO(appointment, doctor, patient));
            }

            return resultAppointments;
        }

        public async Task<Appointment?> AddAppointment(int doctorId, int patientId)
        {
            if (await GetDoctorById(doctorId) == null || await GetPatientById(patientId) == null) { return null; }

            var newAppointment = await _databaseContext.Appointments.AddAsync(new Appointment { Booking = DateTime.UtcNow, DoctorId = doctorId, PatientId = patientId });

            // TODO check that the appointmen haven't been made yet, (does isFaulted catch this???)
            if (newAppointment.State != EntityState.Added) { return null; }
            await _databaseContext.SaveChangesAsync();

            return newAppointment.Entity;
        }
    }
}
