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
        public async Task<IEnumerable<PatientDTO>> GetPatients()
        {

            List<Patient> patients1 = await _databaseContext.Patients.Include(a => a.Appointments).ToListAsync();
            List<PatientDTO> dtoPatients = new List<PatientDTO>();
            foreach (var patient in patients1)
            {
                PatientDTO patientDTO = new PatientDTO() { Id = patient.Id, FullName = patient.FullName, Appointments = AppointmentDTO.CreateAppointmentDTO(patient.Appointments.ToList()) };
                dtoPatients.Add(patientDTO);
            }
            var patients = from b in _databaseContext.Patients.Include(a => a.Appointments)
                           select new PatientDTO()
                           {
                               Id = b.Id,
                               FullName = b.FullName,
                               Appointments = AppointmentDTO.CreateAppointmentDTO(b.Appointments.ToList())
                           };
            return dtoPatients;
        }
        public async Task<PatientDTO> GetPatient(int id)
        {
            var patient = await _databaseContext.Patients.Include(a => a.Appointments).SingleOrDefaultAsync(a => a.Id == id);
            PatientDTO dto = new PatientDTO()
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = AppointmentDTO.CreateAppointmentDTO(patient.Appointments.ToList())
            };

            return dto;
        }
        public async Task<Patient> CreatePatient(string name)
        {
            Patient newPatient = new Patient() { FullName = name };
            await _databaseContext.Patients.AddAsync(newPatient);
            await _databaseContext.SaveChangesAsync();

            return newPatient;
        }
        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            var doctors = from b in _databaseContext.Doctors.Include(a => a.Appointments)
                          select new DoctorDTO()
                          {
                              Id = b.Id,
                              FullName = b.FullName,
                              Appointments = AppointmentDTO.CreateAppointmentDTO(b.Appointments.ToList())
                          };
            return doctors;
        }

        public async Task<DoctorDTO> GetDoctor(int id)
        {
            var doctor = await _databaseContext.Doctors.Include(a => a.Appointments).SingleOrDefaultAsync(a => a.Id == id);
            DoctorDTO dto = new DoctorDTO()
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Appointments = AppointmentDTO.CreateAppointmentDTO(doctor.Appointments.ToList())
            };

            return dto;
        }
        public async Task<Doctor> CreateDoctor(string name)
        {
            Doctor doctor = new Doctor() { FullName = name };
            await _databaseContext.Doctors.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();

            return doctor;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointments()
        {
            var appointments = from b in _databaseContext.Appointments
                               select new AppointmentDTO()
                               {
                                   Doctor_Id = b.DoctorId,
                                   Patient_Id = b.PatientId,
                                   BookingTime = b.Booking
                               };
            return appointments;
        }

        public async Task<AppointmentDTO> GetAppointmentByDoctorAndPatient(int patientId, int doctorId)
        {
            var appointment = _databaseContext.Appointments.FirstOrDefaultAsync(x => x.PatientId == patientId && x.DoctorId == doctorId).Result;
            AppointmentDTO dto = new AppointmentDTO()
            {
                Doctor_Id = doctorId,
                Patient_Id = patientId,
                BookingTime = appointment.Booking
            };

            return dto;
        }

        public async Task<AppointmentDTO> GetAppointmentByPatient(int patientId)
        {
            var appointment = _databaseContext.Appointments.FirstOrDefaultAsync(x => x.PatientId == patientId).Result;
            AppointmentDTO dto = new AppointmentDTO()
            {
                Doctor_Id = appointment.DoctorId,
                Patient_Id = patientId,
                BookingTime = appointment.Booking
            };
            return dto;
        }

        public async Task<AppointmentDTO> GetAppointmentByDoctor(int doctorId)
        {
            var appointment = _databaseContext.Appointments.FirstOrDefaultAsync(x => x.DoctorId == doctorId).Result;
            AppointmentDTO dto = new AppointmentDTO()
            {
                Doctor_Id = doctorId,
                Patient_Id = appointment.PatientId,
                BookingTime = appointment.Booking
            };
            return dto;
        }
        public async Task<Appointment> CreateAppointment(int patientId, int doctorId)
        {
            Appointment appointment = new Appointment() { PatientId = patientId, DoctorId = doctorId, Booking = DateTime.UtcNow };
            await _databaseContext.Appointments.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }
    }
}
