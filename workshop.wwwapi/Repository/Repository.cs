using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{  /// <summary>
   /// Generic Repository with some basic CRUD
   /// </summary>
   /// <typeparam name="T">The generic type with which to perform database operations on</typeparam>
    public class Repository(DatabaseContext db) : IRepository
    {


        public async Task<Patient> CreatePatient(string fullName)
        {
            var p = new Patient() { FullName = fullName };
            await db.Patients.AddAsync(p);
            return p;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await db.Patients
                .Include(p => p.Appointments)
                .ThenInclude(p => p.Doctor)
                .ToListAsync();

        }

        public async Task<Patient> GetPatientById(int id)
        {
            return (await db.Patients
                .Include(p => p.Appointments)
                .ThenInclude(p => p.Doctor)
                .FirstOrDefaultAsync(x => x.Id == id))!;
        }


        public async Task<Doctor> CreateDoctor(string fullName)
        {
            var d = new Doctor() { FullName = fullName };
            await db.Doctors.AddAsync(d);
            return d;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await db.Doctors
                .Include(p => p.Appointments)
                .ThenInclude(p => p.Patient)
                .ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return (await db.Doctors
                .Include(x => x.Appointments)
                .ThenInclude(p => p.Patient)
                .FirstOrDefaultAsync(x => x.Id == id))!;
        }

        public async Task<Appointment> CreateAppointment(int patientId, int doctorId, DateTime booking)
        {
            var result = new Appointment() { PatientId = patientId, DoctorId = doctorId, Booking = booking };
            await db.Appointments.AddAsync(result);
            await db.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await db.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int patientId, int doctorId)
        {
            return await db.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .Where(a => a.PatientId == patientId && a.DoctorId == doctorId)
                .FirstOrDefaultAsync();
        }

 


    }
    
}