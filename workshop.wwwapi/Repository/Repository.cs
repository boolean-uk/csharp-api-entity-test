using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Security.Cryptography.Xml;
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
        public async Task<IEnumerable<PatientDTO>> GetPatients()
        {
            var patients = from patient in _databaseContext.Patients
                           select new PatientDTO()
                           {
                               Id = patient.Id,
                               FullName = patient.FullName, 
                               Appointments = patient.Appointments.Select(x => new AppointmentDTO()
                               { 
                                   Booking = x.Booking,
                                   DoctorId = x.DoctorId,
                                   DoctorName = x.Doctor.FullName,
                                   PatientId = x.PatientId,
                                   PatientName = x.Patient.FullName
                               })
                           };
            return await patients.ToListAsync();

        }

        public async Task<PatientDTO> GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients.Select(p => new PatientDTO() 
            {  
                Id = p.Id, 
                FullName = p.FullName,
                Appointments = p.Appointments.Select(x => new AppointmentDTO()
                {
                    Booking = x.Booking,
                    DoctorId = x.DoctorId,
                    DoctorName = x.Doctor.FullName,
                    PatientId = x.PatientId,
                    PatientName = x.Patient.FullName
                })
            }).SingleOrDefaultAsync(p => p.Id == id);
            return patient;
        }

        public async Task<Patient> CreatePatient(PatientPost patient, int id)
        {
            var createPatient = new Patient()
            {
                Id = id,
                FullName = patient.FullName

            };

            _databaseContext.Patients.Add(createPatient);
            await _databaseContext.SaveChangesAsync();

            return createPatient;
        }

        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            var doctors = from doctor in _databaseContext.Doctors
                           select new DoctorDTO()
                           {
                               Id = doctor.Id,
                               FullName = doctor.FullName,
                               Appointments = doctor.Appointments.Select(x => new AppointmentDTO()
                               {
                                   Booking = x.Booking,
                                   DoctorId = x.DoctorId,
                                   DoctorName = x.Doctor.FullName,
                                   PatientId = x.PatientId,
                                   PatientName = x.Patient.FullName
                               })
                           };
            return await doctors.ToListAsync();
        }

        public async Task<DoctorDTO> GetDoctorById(int id)
        {
            var doctor = await _databaseContext.Doctors.Select(d => new DoctorDTO()
            {
                Id = d.Id,
                FullName = d.FullName,
                Appointments = d.Appointments.Select(x => new AppointmentDTO()
                {
                    Booking = x.Booking,
                    DoctorId = x.DoctorId,
                    DoctorName = x.Doctor.FullName,
                    PatientId = x.PatientId,
                    PatientName = x.Patient.FullName
                })
            }).SingleOrDefaultAsync(p => p.Id == id);
            return doctor;
        }
        public async Task<DoctorDTO> CreateDoctor(CreateDoctorDTO createDoctorDTO)
        {
            var doctor = new Doctor
            {
                FullName = createDoctorDTO.FullName

            };

            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();

            return new DoctorDTO { Id = doctor.Id, FullName = doctor.FullName };
        }

      

        public async Task<IEnumerable<AppointmentDTO>> GetAppointments()
        {
            var appointments = from a in _databaseContext.Appointments
                           select new AppointmentDTO()
                           {
                               PatientId = a.PatientId,
                               DoctorId = a.DoctorId,
                               Booking = a.Booking,
                               DoctorName = a.Doctor.FullName,
                               PatientName = a.Patient.FullName,
                           };
            return await appointments.ToListAsync();
        }

        public async Task<AppointmentDTO> GetAppointmentById(int DoctorId, int PatientId)
        {
            var appointment = await _databaseContext.Appointments
                .Where(a => a.DoctorId == DoctorId && a.PatientId == PatientId)
                .Select(appointment => new AppointmentDTO()
                {
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    Booking = appointment.Booking,
                    DoctorName = appointment.Doctor.FullName,
                    PatientName = appointment.Patient.FullName,
                }).FirstOrDefaultAsync();

            return appointment;

        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor (int DoctorId)
        {
            var appointments = from a in _databaseContext.Appointments where a.DoctorId == DoctorId
                               select new AppointmentDTO()
                               {
                                   PatientId = a.PatientId,
                                   DoctorId = a.DoctorId,
                                   Booking = a.Booking,
                                   DoctorName = a.Doctor.FullName,
                                   PatientName = a.Patient.FullName,

                               };
            return await appointments.ToListAsync();
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(int PatientId)
        {
            var appointments = from a in _databaseContext.Appointments where a.PatientId == PatientId
                               select new AppointmentDTO()
                               {
                                   PatientId = a.PatientId,
                                   DoctorId = a.DoctorId,
                                   Booking = a.Booking,
                                   DoctorName = a.Doctor.FullName,
                                   PatientName = a.Patient.FullName,
                               };
            return await appointments.ToListAsync();
        }

        public async Task<AppointmentDTO> CreateAppointment(CreateAppointmentDTO appointmentDTO)
        {
            try
            {
                var appointment = new Appointment()
                {
                    PatientId = appointmentDTO.PatientId,
                    DoctorId = appointmentDTO.DoctorId,
                    Booking = appointmentDTO.Booking, // Using the booking time from the DTO
                    Patient = _databaseContext.Patients.Include(a => a.Appointments).FirstOrDefault(x => x.Id == appointmentDTO.PatientId),
                    Doctor = _databaseContext.Doctors.Include(a => a.Appointments).FirstOrDefault(x => x.Id == appointmentDTO.DoctorId),
                };

                _databaseContext.Appointments.Add(appointment);
                await _databaseContext.SaveChangesAsync();

                return new AppointmentDTO()
                {
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    Booking = appointment.Booking,
                    DoctorName = appointment.Doctor.FullName,
                    PatientName= appointment.Patient.FullName
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}
