using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _db;
        public Repository(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _db.Patients.Include(y => y.Appointments).ToListAsync();
        }
        public async Task<Patient?> GetPatient(int id)
        {
            return await _db.Patients.Include(y => y.Appointments).SingleOrDefaultAsync(y => y.Id == id);
        }
        public async Task<Patient?> CreatePatient(string name)
        {
            //Create patient to return
            Patient patient = new Patient();
            //Populate the patient with payload data
            patient.FullName = name;
            //add patient to database and save it + return
            _db.Patients.Add(patient);
            _db.SaveChanges();
            return patient;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _db.Doctors.Include(y => y.Appointments).ToListAsync();
        }
        public async Task<Doctor?> GetDoctor(int id)
        {
            return await _db.Doctors.Include(y => y.Appointments).SingleOrDefaultAsync(y => y.Id == id);
        }
        public async Task<Doctor?> CreateDoctor(string name)
        {
            //Create doctor to return
            Doctor doctor = new Doctor();
            //Populate the doctor with payload data
            doctor.FullName = name;
            //add doctor to database and save it + return
            _db.Doctors.Add(doctor);
            _db.SaveChanges();
            return doctor;
        }
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _db.Appointments.ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _db.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _db.Appointments.Where(a => a.PatientId == id).ToListAsync();
        }
        public async Task<Appointment> CreateAppointment(int DoctorId, int PatientId)
        {
            //Create appointment to return
            Appointment appointment = new Appointment();
            //Populate the appointment with payload data
            appointment.Booking = DateTime.Now.AddMonths(2).ToUniversalTime();
            appointment.DoctorId = DoctorId;
            appointment.PatientId = PatientId;
            //add appointment to database and save it + return
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return appointment;
        }

    }
}
