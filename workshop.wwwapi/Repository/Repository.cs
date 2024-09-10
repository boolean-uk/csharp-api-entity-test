using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Patient_DTO>> GetPatients()
        {
            List<Patient> patients = await _databaseContext.Patients.Include(a => a.appointments).ToListAsync();
            List<Patient_DTO> patients_DTO = new List<Patient_DTO>();
            foreach(Patient patient in patients)
            {
                patients_DTO.Add(new Patient_DTO(patient));
            }
            return patients_DTO;
        }

        public async Task<Patient_DTO> GetPatientById(int id)
        {
            Patient patient = await _databaseContext.Patients.Include(a => a.appointments).SingleOrDefaultAsync(a => a.Id == id);
            return new Patient_DTO(patient);
        }

        public async Task<IEnumerable<Doctor_DTO>> GetDoctors()
        {
            List<Doctor> doctors =  await _databaseContext.Doctors.Include(a => a.appointments).ToListAsync();
            List<Doctor_DTO> doctors_DTO = new List<Doctor_DTO>();
            foreach (Doctor doctor in doctors)
            {
                doctors_DTO.Add(new Doctor_DTO(doctor));
            }
            return doctors_DTO;
        }
        public async Task<IEnumerable<Appointment_DTO>> GetAppointmentsByDoctor(int id)
        {
            List<Appointment> appointments =  await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
            List<Appointment_DTO> appointments_DTO = new List<Appointment_DTO>();
            foreach(Appointment appointment in appointments)
            {
                appointments_DTO.Add(new Appointment_DTO(appointment));
            }
            return appointments_DTO;
        }

        public async Task<IEnumerable<Appointment_DTO>> GetAppointmentsByPatient(int id)
        {
            List<Appointment> appointments = await _databaseContext.Appointments.Where(a => a.PatientId == id).ToListAsync();
            List<Appointment_DTO> appointments_DTO = new List<Appointment_DTO>();
            foreach (Appointment appointment in appointments)
            {
                appointments_DTO.Add(new Appointment_DTO(appointment));
            }
            return appointments_DTO;
        }
        public async Task<Doctor_DTO> GetDoctorById(int id)
        {
            Doctor doctor = await _databaseContext.Doctors.Include(a => a.appointments).SingleOrDefaultAsync(a => a.Id == id);
            return new Doctor_DTO(doctor);
        }

        public async Task<Doctor_DTO> AddDoctor(string doctorName)
        {
            Doctor doctor = new Doctor()
            {
                FullName = doctorName
            };
            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();
            Doctor_DTO doctor_DTO = await GetDoctorById(doctor.Id);
            return doctor_DTO;
        }

        public async Task<Appointment_DTO> AddAppointment(int DoctorId, int PatientId)
        {
            Appointment appointment = new Appointment()
            {
                DoctorId = DoctorId,
                PatientId = PatientId,
                Booking = DateTime.UtcNow
            };
            Appointment_DTO appointment_DTO = new Appointment_DTO(appointment);
            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment_DTO;
        }
    }
}
