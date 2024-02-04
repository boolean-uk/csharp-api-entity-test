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

        /// <summary>
        /// Get all the patients
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.Include(a => a.Appointments).ToListAsync();
        }

        /// <summary>
        /// Get doctors
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(a => a.Appointments).ToListAsync();
        }


 

        /// <summary>
        /// Get a patient by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Patient> GetPatient(int? id)
        {
            Patient patient = await  _databaseContext.Patients.Include(a => a.Appointments).FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null) { throw new Exception("No match id."); }
            return patient; 
        }

        /// <summary>
        /// Get a Doctor by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Doctor> GetADoctor(int? id)
        {
            Doctor doctor = await _databaseContext.Doctors.Include(a => a.Appointments).FirstOrDefaultAsync(d => d.Id == id) ?? throw new ArgumentException("No match for this id");
            return doctor;
        }

        /// <summary>
        /// Add a doctor
        /// </summary>
        /// <param name="newDoctor"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="BadHttpRequestException"></exception>
        public async Task<Doctor> AddDoctor(InnDoctorDTO newDoctor)
        {
            if ( newDoctor.FullName == null) { throw new ArgumentException("Invalid input"); }
            else if (_databaseContext.Doctors.Any(d => d.FullName == newDoctor.FullName))
            {

                throw new BadHttpRequestException("The doctor is already exist");
            }
            else {
                Doctor doctor = new Doctor {
                    FullName = newDoctor.FullName,
                    
                };
                await _databaseContext.AddAsync(doctor);
                await _databaseContext.SaveChangesAsync();
                return doctor;
            }

        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            List<Appointment> appointment = await _databaseContext.Appointments.Include(d => d.Doctor).Include(p => p.Patient).Where(a => a.DoctorId == id).ToListAsync();
            if (appointment == null) {throw new ArgumentException("No match for this id"); }
            return appointment;
           
        }

        public async Task<Appointment> GetAnAppointment(int id1, int id2)
        {
            Appointment appointment = await _databaseContext.Appointments.Include(d => d.Doctor).Include(p => p.Patient).FirstOrDefaultAsync(a => a.PatientId == id1 && a.DoctorId == id2);
            if (appointment == null) { throw new ArgumentException("No match for this id"); }
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            List<Appointment> appointment = await _databaseContext.Appointments.Include(d => d.Doctor).Include(p => p.Patient).Where(a => a.PatientId == id).ToListAsync();
            if (appointment == null) { throw new ArgumentException("No match for this id"); }
            return appointment;

        }

    }
}
