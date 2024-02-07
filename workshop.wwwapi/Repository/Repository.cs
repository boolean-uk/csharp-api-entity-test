using Microsoft.EntityFrameworkCore;
using System.Numerics;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTO;
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
        public async Task<IEnumerable<PatientDto>> GetPatients()
        {
            var patients = from patient in _databaseContext.Patients
                           select new PatientDto()
                           {
                               Id = patient.Id,
                               FullName = patient.FullName,
                               Appointments = patient.Appointments.Select(x => new AppointmentDto()
                               {
                                   Booking = x.Booking,
                                   DoctorId = x.DoctorId,
                                   DoctorName = x.Doctor.FullName,
                                   PatientId = x.PatientId,
                                   PatientName = x.Patient.FullName,
                                   Type = x.Type
                               })
                           };
            return await patients.ToListAsync();
        }
        public async Task<PatientDto> GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients.Select(p => new PatientDto()
            {
                Id = p.Id,
                FullName = p.FullName,
                Appointments = p.Appointments.Select(x => new AppointmentDto()
                {
                    Booking = x.Booking,
                    DoctorId = x.DoctorId,
                    DoctorName = x.Doctor.FullName,
                    PatientId = x.PatientId,
                    PatientName = x.Patient.FullName,
                    Type = x.Type
                })
            }).SingleOrDefaultAsync(p => p.Id == id);
            return patient;
        }

        public async Task<Patient> CreatePatient(PatientPost patient, int id)
        {
            Patient createPatient = new Patient()
            {
                Id = id,
                FullName = patient.FullName
            };

            _databaseContext.Add(createPatient);
            _databaseContext.SaveChanges();
            return createPatient;
        }
        public async Task<IEnumerable<DoctorDto>> GetDoctors()
        {
            var doctors = from doctor in _databaseContext.Doctors
                           select new DoctorDto()
                           {
                               Id = doctor.Id,
                               FullName = doctor.FullName,
                               Appointments = doctor.Appointments.Select(x => new AppointmentDto()
                               {
                                   Booking = x.Booking,
                                   DoctorId = x.DoctorId,
                                   DoctorName = x.Doctor.FullName,
                                   PatientId = x.PatientId,
                                   PatientName = x.Patient.FullName,
                                   Type = x.Type
                               })
                           };
            return await doctors.ToListAsync();
        }
        
        public async Task<DoctorDto> GetDoctorById(int id)
        {
            var doctor = await _databaseContext.Doctors.Select(d => new DoctorDto()
            {
                Id = d.Id,
                FullName = d.FullName,
                Appointments = d.Appointments.Select(x => new AppointmentDto()
                {
                    Booking = x.Booking,
                    DoctorId = x.DoctorId,
                    DoctorName = x.Doctor.FullName,
                    PatientId = x.PatientId,
                    PatientName = x.Patient.FullName,
                    Type = x.Type
                })
            }).SingleOrDefaultAsync(d => d.Id == id);
            return doctor;
        }
        
        public async Task<Doctor> CreateDoctor(DoctorPost doctor, int id)
        {
            Doctor createDoctor = new Doctor()
            {
                Id = id,
                FullName = doctor.FullName
            };

            _databaseContext.Add(createDoctor);
            _databaseContext.SaveChanges();
            return createDoctor;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointments()
        {
            var appointments = from appointment in _databaseContext.Appointments
                               select new AppointmentDto()
                               {
                                   Booking = appointment.Booking,
                                   DoctorId = appointment.DoctorId,
                                   DoctorName = appointment.Doctor.FullName,
                                   PatientId = appointment.PatientId,
                                   PatientName = appointment.Patient.FullName,
                                   Type = appointment.Type
                               };
            return await appointments.ToListAsync();
        }

        public async Task<AppointmentDto> GetAppointmentById(int doctorId, int patientId)
        {
            var appointment = await _databaseContext.Appointments.Where(a => a.DoctorId == doctorId && a.PatientId == patientId)
                .Select(a => new AppointmentDto()
            {
                Booking = a.Booking,
                DoctorId = a.DoctorId,
                DoctorName = a.Doctor.FullName,
                PatientId = a.PatientId,
                PatientName = a.Patient.FullName,
                Type = a.Type

                }).FirstOrDefaultAsync();
            return appointment;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctor(int doctorId)
        {
            var appointments = from appointment in _databaseContext.Appointments
                               where appointment.DoctorId == doctorId
                               select new AppointmentDto()
                               {
                                   Booking = appointment.Booking,
                                   DoctorId = appointment.DoctorId,
                                   DoctorName = appointment.Doctor.FullName,
                                   PatientId = appointment.PatientId,
                                   PatientName = appointment.Patient.FullName,
                                   Type = appointment.Type
                               };
            return await appointments.ToListAsync();
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentByPatient(int patientId)
        {
            var appointments = from appointment in _databaseContext.Appointments
                               where appointment.PatientId == patientId
                               select new AppointmentDto()
                               {
                                   Booking = appointment.Booking,
                                   DoctorId = appointment.DoctorId,
                                   DoctorName = appointment.Doctor.FullName,
                                   PatientId = appointment.PatientId,
                                   PatientName = appointment.Patient.FullName,
                                   Type = appointment.Type
                               };
            return await appointments.ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(AppointmentPost appointment, int doctorId, int patientId)
        {
            // for the sake of exercise, randomly selects appointment type, assume doctorId 2 only takes online appointments
            AppointmentType type;
            if (doctorId == 2)
            {
                type = AppointmentType.Online;

            }
            else { type = AppointmentType.InPerson; }

            Appointment createAppointment = new Appointment()
            {
                Booking = appointment.Booking,
                DoctorId = doctorId,
                Doctor = _databaseContext.Doctors.Include(a => a.Appointments).FirstOrDefault(x => x.Id == doctorId),
                PatientId = patientId,
                Patient = _databaseContext.Patients.Include(a => a.Appointments).FirstOrDefault(x => x.Id == patientId),
                Type = type
            };

            _databaseContext.Add(createAppointment);
            _databaseContext.SaveChanges();
            return createAppointment;
        }
    }
}
