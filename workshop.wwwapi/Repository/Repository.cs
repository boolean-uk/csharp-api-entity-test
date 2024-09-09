using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.ViewModel;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _db;
        public Repository(DatabaseContext db)
        {
            _db = db;
        }

        //--Patient--
        public async Task<IEnumerable<PatientDTO>> GetPatients()
        {
            //Get patients
            var patients = await _db.Patients.ToListAsync();
            List<PatientDTO> result = new List<PatientDTO>();
            foreach(var patient in patients)
            {
                result.Add(ConstructPatientDTO(patient));
            }

            //Response
            return result;
        }
        public async Task<PatientDTO> GetPatient(int id)
        {
            //Get patient
            var patient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null)
            {
                throw new Exception("Patient not found");
            }

            //Response
            return ConstructPatientDTO(patient);
        }
        public async Task<PatientDTO> AddPatient(Patient entity)
        {
            //Add patient
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();

            //Response
            return ConstructPatientDTO(entity);
        }
        private PatientDTO ConstructPatientDTO(Patient patient)
        {
            return new PatientDTO(patient, _db.Appointments.ToList(), _db.Doctors.ToList());
        }



        //--Doctor--
        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            //Get doctors
            var doctors = await _db.Doctors.ToListAsync();
            List<DoctorDTO> result = new List<DoctorDTO>();
            foreach (var doctor in doctors)
            {
                result.Add(ConstructDoctorDTO(doctor));
            }

            //Response
            return result;
        }
        public async Task<DoctorDTO> GetDoctor(int id)
        {
            //Get doctor
            var doctor = await _db.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }

            //Response
            return ConstructDoctorDTO(doctor);
        }
        public async Task<DoctorDTO> AddDoctor(Doctor entity)
        {
            //Add doctor
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();

            //Response
            return ConstructDoctorDTO(entity);
        }
        private DoctorDTO ConstructDoctorDTO(Doctor doctor)
        {
            return new DoctorDTO(doctor, _db.Appointments.ToList(), _db.Patients.ToList());
        }



        //--Appointment--
        public async Task<IEnumerable<AppointmentDTO>> GetAppointments()
        {
            //Get appointments
            var appointments = await _db.Appointments.ToListAsync();
            List<AppointmentDTO> result = new List<AppointmentDTO>();
            foreach (var appointment in appointments)
            {
                result.Add(ConstructAppointmentDTO(appointment));
            }

            //Response
            return result;
        }
        public async Task<AppointmentDTO> GetAppointment(int id)
        {
            //Get appointment
            var appointment = await _db.Appointments.Where(a => a.Id == id).FirstOrDefaultAsync();
            if(appointment == null)
            {
                throw new Exception("Appointment not found");
            }

            //Response
            return ConstructAppointmentDTO(appointment);
        }
        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id)
        {
            //Get appointments
            var appointments = await _db.Appointments.Where(a => a.DoctorId == id).ToListAsync();
            List<AppointmentDTO> result = new List<AppointmentDTO>();
            foreach (var appointment in appointments)
            {
                result.Add(ConstructAppointmentDTO(appointment));
            }

            //Response
            return result;
        }
        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(int id)
        {
            //Get appointments
            var appointments = await _db.Appointments.Where(a => a.PatientId == id).ToListAsync();
            List<AppointmentDTO> result = new List<AppointmentDTO>();
            foreach(var appointment in appointments)
            {
                result.Add(ConstructAppointmentDTO(appointment));
            }

            //Response
            return result;
        }
        public async Task<AppointmentDTO> AddAppointment(Appointment entity)
        {
            //Add appointment
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();

            //Response
            return ConstructAppointmentDTO(entity);
        }
        private AppointmentDTO ConstructAppointmentDTO(Appointment appointment)
        {
            return new AppointmentDTO(appointment, _db.Patients.ToList(), _db.Doctors.ToList());
        }
    }
}
