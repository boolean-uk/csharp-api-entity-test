using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using workshop.wwwapi.Data;
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

        //get all patients
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToListAsync();
        }

        //get patient by ID
        public async Task<Patient?> GetPatientByID(int id)
        {
            var patient = await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return null;
            }
            return patient;
        }

        //create patient
        public async Task<Patient> CreatePatient(string name)
        {
            var patients = await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToListAsync();

            var lastPatient = patients.OrderByDescending(p => p.Id)
                .FirstOrDefault();
            int newPatientId = (lastPatient != null) ? lastPatient.Id + 1 : 1;

            Patient patient = new Patient();
            patient.Id = newPatientId;
            patient.FullName = name;

            _databaseContext.Patients.Add(patient);
            _databaseContext.SaveChanges();
            return patient;
        }

        //get all doctors
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .ToListAsync();
        }

        //get doctor by ID
        public async Task<Doctor?> GetDoctorByID(int id)
        {

            var doctor = await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(d => d.Id == id);
            
            if (doctor == null)
            {
                return null;
            }
            return doctor;
        }

        //create doctor
        public async Task<Doctor> CreateDoctor(string name)
        {
            var doctors = await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .ToListAsync();

            var lastDoctor = doctors.OrderByDescending(d => d.Id).FirstOrDefault();
            int newDoctorId = (lastDoctor != null) ? lastDoctor.Id + 1 : 1;

            Doctor doctor = new Doctor();
            doctor.Id = newDoctorId;
            doctor.FullName = name;

            _databaseContext.Doctors.Add(doctor);
            _databaseContext.SaveChanges();
            return doctor;
        }

        //get all appointments
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }

        //get appointments by doctorID
        public async Task<IEnumerable<Appointment?>> GetAppointmentsByDoctorID(int doctorId)
        {
            var appointment = await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
            
            if (appointment == null)
            {
                return null;
            }
            return appointment;
        }

        //get appointments by patientID
        public async Task<IEnumerable<Appointment?>> 
            GetAppointmentsByPatientID(int patientId)
        {
            var appointment = await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Where(a => a.PatientId == patientId)
                .ToListAsync();

            if (appointment == null)
            {
                return null;
            }
            return appointment;
        }

        //create new appointment
        public async Task<Appointment> CreateAppointment(int doctorId, 
            int patientId, DateTime appointmentTime)
        {
            var doctor = await _databaseContext.Doctors.FindAsync(doctorId);
            var patient = await _databaseContext.Patients.FindAsync(patientId);

            if (doctor == null || patient == null)
            {
                return null;
            }

            var appointment = new Appointment
            {
                DoctorId = doctorId,
                PatientId = patientId,
                AppointmentDate = appointmentTime
            };

            _databaseContext.Appointments.Add(appointment);
            _databaseContext.SaveChanges();
            return appointment;
        }

        //Get all prescriptions
        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Doctor)
                .Include(p => p.medicinePrescriptions)
                    .ThenInclude(m => m.Medicine)
                .ToListAsync();
        }

        //get prescription by ID
        public async Task<Prescription?> GetPrescriptionByID(int id)
        {
            return await _databaseContext.Prescriptions
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Doctor)
                .Include(p => p.medicinePrescriptions)
                    .ThenInclude(m => m.Medicine)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        //create prescription
        public async Task<Prescription> 
            CreatePrescription(string name, int appointmentId, int medicineId)
        {
            // add to prescriptionTable
            Prescription prescription = new Prescription();
            prescription.Name = name;
            prescription.AppointmentId = appointmentId;
            _databaseContext.Prescriptions.Add(prescription);
            await _databaseContext.SaveChangesAsync();

            MedicinePrescription medicinePrescription = new MedicinePrescription();
            medicinePrescription.PrescriptionId = prescription.Id;
            medicinePrescription.MedicineId = medicineId;
            _databaseContext.MedicinePrescriptions.Add(medicinePrescription);
            await _databaseContext.SaveChangesAsync();

            return await GetPrescriptionByID(prescription.Id);
        }
    }
}