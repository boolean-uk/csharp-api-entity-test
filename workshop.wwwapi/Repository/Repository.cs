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
        public async Task<IEnumerable<PatientDTO>> GetPatients()
        {
            var patientsDTO = new List<PatientDTO>();
            var patients = await _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(d => d.Doctor).ToListAsync();
            patients.ForEach(p => patientsDTO.Add(new PatientDTO(p))); //converting each Patient to PatientDTO
            return patientsDTO;
        }
        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            var doctorsDTO = new List<DoctorDTO>();
            var doctors = await _databaseContext.Doctors.Include(a =>a.Appointments).ThenInclude(p => p.Patient).ToListAsync();
            doctors.ForEach(d => doctorsDTO.Add(new DoctorDTO(d)));
            return doctorsDTO ;
        }
        public async Task<IEnumerable<AppointmentDTO>> GetAppointments()
        {
            var appointmentsDTO = new List<AppointmentDTO>();
            var appointments  = await _databaseContext.Appointments.Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();
            appointments.ForEach(a => appointmentsDTO.Add(new AppointmentDTO(a)));
            return appointmentsDTO;
        }
        public async Task<IEnumerable<AppointmentDTO>> GetApointment(int patientid, int doctorid)
        {
            List<Appointment>appointments = await _databaseContext.Appointments.Include(a=> a.Patient).Include(a=>a.Doctor).Where(a => a.PatientId == patientid && a.DoctorId == doctorid).ToListAsync();
            List<AppointmentDTO> apointmentsDTO = new List<AppointmentDTO>();
            appointments.ForEach(a => apointmentsDTO.Add(new AppointmentDTO(a)));

            return apointmentsDTO;
        }
        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id)
        {
            var appointmentsDTO = new List<AppointmentDTO>();
            var appointments = await _databaseContext.Appointments.Include(a=> a.Patient).Include(a=>a.Doctor).Where(a => a.DoctorId == id).ToListAsync();
            appointments.ForEach(a => appointmentsDTO.Add(new AppointmentDTO(a)));
            return appointmentsDTO;
        }

        public async Task<PatientDTO> GetPatient(int id)
        {
            List<Patient> patients = await _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(p => p.Doctor).ToListAsync();
            var patient = patients.Find(p => p.Id == id);
                
            return new PatientDTO(patient);
        }
        public async Task<DoctorDTO> GetDoctor(int id)
        {
            var doctors = await _databaseContext.Doctors.Include(a => a.Appointments).ThenInclude(a => a.Patient).ToListAsync();
            Doctor doctor = doctors.Find(x=> x.Id==id);
            return new DoctorDTO(doctor);
        }
        public async Task<IEnumerable<DoctorDTO>> CreateDoctor( string fullname)
        {
            Doctor doctor = new Doctor { FullName= fullname};
            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();
            var doctorsDTO = new List<DoctorDTO>();
            var doctors = await _databaseContext.Doctors.Include(a => a.Appointments).ThenInclude(a => a.Patient).ToListAsync();
            doctors.ForEach(d => doctorsDTO.Add(new DoctorDTO(d)));
            return doctorsDTO;
        }
        public async Task<IEnumerable<AppointmentDTO>>CreateAppointment(int doctorid,int patientid, DateTime datetime)
        {
            try
            {
                Appointment appointment = new Appointment
                {
                    DoctorId = doctorid,
                    PatientId = patientid,
                    Booking = datetime
                };

                _databaseContext.Appointments.Add(appointment);
                return await GetAppointments();
            }
            catch (Exception e) //probalby datetime parsing error
            {
          
                return await GetAppointments();
            }                 
        }
    }
}
