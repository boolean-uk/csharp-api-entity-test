using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs.Extension;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Post.Core;
using workshop.wwwapi.Models.Post.Extension;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }


        //PATIENTS
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        public async Task<Patient?> GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return patient;
        }

        public async Task<Patient> CreatePatient(PatientPost model)
        {
            int newId = _databaseContext.Patients.Any() ? _databaseContext.Patients.Max(p => p.Id) + 1 : 1;

            var patient = new Patient
            {
                Id = newId,
                FullName = model.FullName
            };

            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }


        //DOCTORS
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .OrderBy(d => d.Id)
                .ToListAsync();
        }

        public async Task<Doctor?> GetDoctorById(int id)
        {
            var doctor = await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();
            return doctor;
        }

        public async Task<Doctor> CreateDoctor(DoctorPost model)
        {
            int newId = _databaseContext.Patients.Any() ? _databaseContext.Patients.Max(p => p.Id) + 1 : 1;

            var doctor = new Doctor
            {
                Id = newId,
                FullName = model.FullName
            };

            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }


        //APPOINTMENTS
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId == id)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(AppointmentPost model)
        {
            var doctor = await GetDoctorById(model.DoctorId);
            var patient = await GetPatientById(model.PatientId);

            int newId = _databaseContext.Appointments.Any() ? _databaseContext.Appointments.Max(a => a.Id) + 1 : 1;
            var appointment = new Appointment
            {
                Id = newId,
                DoctorId = model.DoctorId,
                Doctor = doctor,
                PatientId = model.PatientId,
                Patient = patient,
                AppointmentType = model.AppointmentType,
                Booking = model.Booking
            };
            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }


        //MEDICINEPRESCRIPTIONS

        public async Task<IEnumerable<MedicinePrescription>> GetMedicinePrescriptions()
        {
            return await _databaseContext.MedicinePrescriptions
                .Include(m => m.Medicine)
                .Include(m => m.Prescription)
                    .ThenInclude(p => p.Appointment)
                        .ThenInclude(a => a.Doctor)
                 .Include(m => m.Prescription)
                    .ThenInclude(p => p.Appointment) 
                        .ThenInclude(a => a.Patient)
                .OrderBy(m => m.Id)
                .ToListAsync();
        }

        public async Task<MedicinePrescription?> GetMedicinePrescriptionsById(int id)
        {
            var mp = await _databaseContext.MedicinePrescriptions
                .Include(m => m.Medicine)
                .Include(m => m.Prescription)
                    .ThenInclude(p => p.Appointment)
                        .ThenInclude(a => a.Doctor)
                 .Include(m => m.Prescription)
                    .ThenInclude(p => p.Appointment)
                        .ThenInclude(a => a.Patient)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
            return mp;
        }

        /* Late in the day and I just thought really backwards, or not thinking at all.
        public async Task<MedicinePrescription> CreateMedicinePrescription(MedicinePrescriptionPost model)
        {
            var medicine =      await _databaseContext.Medicines.FindAsync(model.MedicineId);
            var prescription =  await _databaseContext.Prescriptions.FindAsync(model.PrescriptionId);
            var appointment =   await _databaseContext.Appointments.FindAsync(model.AppointmentId);

            int newId = _databaseContext.MedicinePrescriptions.Any() ? _databaseContext.MedicinePrescriptions.Max(a => a.Id) + 1 : 1;
            var mp = new MedicinePrescription
            {
                Id = newId,
                MedicineId = model.MedicineId,
                Medicine = medicine,
                PrescriptionId = model.PrescriptionId,
                Prescription = prescription,
                AppointmentId = model.AppointmentId,
                Appointment = appointment
            };
            _databaseContext.MedicinePrescriptions.Add(mp);
            await _databaseContext.SaveChangesAsync();
            return mp;
        }
        */

        public async Task<Medicine?> GetMedicineById(int id)
        {
            var medicine = await _databaseContext.Medicines
                .Include(m => m.MedicinePrescriptions)
                .ThenInclude(mp => mp.Prescription)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
            return medicine;
        }
        public async Task<Appointment?> GetAppointmentById(int id)
        {
            var appointment = await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
            return appointment;
        }

        public async Task<Medicine> CreateMedicine(MedicinePost model)
        {
            int newId = _databaseContext.Patients.Any() ? _databaseContext.Patients.Max(p => p.Id) + 1 : 1;

            var medicine = new Medicine
            {
                Id = newId,
                Name = model.Name,
                Quantity = model.Quantity,
                Instruction = model.Instruction
            };

            _databaseContext.Medicines.Add(medicine);
            await _databaseContext.SaveChangesAsync();
            return medicine;
        }


        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions
                .Include(p=>p.Appointment)
                    .ThenInclude(a=>a.Doctor)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(p => p.MedicinePrescriptions)
                    .ThenInclude(mp => mp.Medicine)
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        public async Task<Prescription?> GetPrescriptionById(int id)
        {
            var prescription = await _databaseContext.Prescriptions
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Doctor)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(p => p.MedicinePrescriptions)
                .ThenInclude(mp => mp.Medicine)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return prescription;
        }
        public async Task<Prescription> CreatePrescription(PrescriptionPost model)
        {
            int newId = _databaseContext.Prescriptions.Any() ? _databaseContext.Prescriptions.Max(p => p.Id) + 1 : 1;

            var prescription = new Prescription
            {
                Id = newId,
                AppointmentId = model.AppointmentId,
                DoctorsNote = model.DoctorsNote
            };

            _databaseContext.Prescriptions.Add(prescription);

            foreach (var medicineId in model.MedicineIds)
            {
                var medicine = await GetMedicineById(medicineId);
                if (medicine == null)
                {
                    return null;
                }
                var mp = new MedicinePrescription
                {
                    MedicineId = medicineId,
                    PrescriptionId = newId
                };
                _databaseContext.MedicinePrescriptions.Add(mp);
            }
            await _databaseContext.SaveChangesAsync();

            await _databaseContext.Entry(prescription).Collection(p => p.MedicinePrescriptions).LoadAsync();

            return prescription;
        }

        public async Task<bool> AreMedicineIDsValid(List<int> medicineIds)
        {
            var existingMedicines = await _databaseContext.Medicines
                .Where(m => medicineIds.Contains(m.Id))
                .Select(m => m.Id)
                .ToListAsync();

            return existingMedicines.Count == medicineIds.Count;
        }
    }
}
