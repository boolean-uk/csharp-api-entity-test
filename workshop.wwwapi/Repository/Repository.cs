using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
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
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(d => d.Doctor).Include(a => a.Appointments).ThenInclude(p => p.Prescription).ToListAsync();
        }

        public async Task<Patient?> GetPatient(int id)
        {
            var patient = await _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(d => d.Doctor).Include(a => a.Appointments).ThenInclude(p => p.Prescription).FirstOrDefaultAsync(b => b.Id == id);
            return patient;
        }

        public async Task<Patient> CreatePatient(string name)
        {
            List<Patient> patients = await _databaseContext.Patients.ToListAsync();
            int id = patients.Last().Id;
            id++;

            var newPatient = new Patient() { Id = id, FullName =  name};
            await _databaseContext.AddAsync(newPatient);
            await _databaseContext.SaveChangesAsync();
            return newPatient;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(a => a.Appointments).ThenInclude(p => p.Patient).Include(a => a.Appointments).ThenInclude(p => p.Prescription).ToListAsync();
        }

        public async Task<Doctor?> GetDoctor(int id)
        {
            var doctor = await _databaseContext.Doctors.Include(a => a.Appointments).ThenInclude(p => p.Patient).Include(a => a.Appointments).ThenInclude(p => p.Prescription).FirstOrDefaultAsync(b => b.Id == id);
            return doctor;
        }

        public async Task<Doctor> CreateDoctor(string name)
        {
            List<Doctor> doctors = await _databaseContext.Doctors.ToListAsync();
            int id = doctors.Last().Id;
            id++;

            var newDoctor = new Doctor() { Id = id, FullName = name };
            await _databaseContext.AddAsync(newDoctor);
            await _databaseContext.SaveChangesAsync();
            return newDoctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(p => p.Patient).Include(p => p.Prescription).ToListAsync();
        }

        public async Task<Appointment?> GetAppointment(string booking)
        {
            var appointment = await _databaseContext.Appointments.Include(a => a.Doctor).Include(p => p.Patient).Include(p => p.Prescription).FirstOrDefaultAsync(b => b.Booking == booking);
            return appointment;
        }

        public async Task<Appointment> CreateAppointment(string booking, int patientId, int doctorId)
        {
            var newAppointment = new Appointment() { Booking = booking, PatientId = patientId, DoctorId = doctorId};
            await _databaseContext.AddAsync(newAppointment);
            await _databaseContext.SaveChangesAsync();
            return newAppointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.Include(a => a.Appointments).ThenInclude(p => p.Patient).Include(a => a.Appointments).ThenInclude(p => p.Doctor).
                Include(p => p.Medicines).ThenInclude(m => m.Medicine).ToListAsync();
        }

        public async Task<Prescription?> GetPrescription(int id)
        {
            var prescription = await _databaseContext.Prescriptions.Include(a => a.Appointments).ThenInclude(p => p.Patient).Include(a => a.Appointments).ThenInclude(p => p.Doctor).FirstOrDefaultAsync(b => b.Id == id);
            return prescription;
        }

        public async Task<Prescription> CreatePrescription(string name, int quantity, string notes)
        {
            List<Prescription> prescriptions = await _databaseContext.Prescriptions.ToListAsync();
            int id = prescriptions.Last().Id;
            id++;
            var newPrescription = new Prescription() { Id = id, Name = name };

            List<Medicine> medicines = await _databaseContext.Medicines.ToListAsync();
            int medId = 0;
            if (medicines.Count > 0)
                medId = medicines.Last().Id;
            medId++;
            var newMedicine = new Medicine() { Id = medId, Quantity = quantity, Notes = notes };

            PrepMedicines pMedicine = new PrepMedicines() { PrescriptionId = id, MedicineId = medId };
            newPrescription.Medicines.Add(pMedicine);
            newMedicine.Prepscriptions.Add(pMedicine);

            await _databaseContext.AddAsync(newPrescription);
            await _databaseContext.AddAsync(newMedicine);
            await _databaseContext.SaveChangesAsync();
            return newPrescription;
        }

        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await _databaseContext.Medicines.Include(p => p.Prepscriptions).ThenInclude(m => m.Prescription).ToListAsync();
        }
    }
}
