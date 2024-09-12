﻿using Microsoft.EntityFrameworkCore;
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
            return await _databaseContext.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Patient> AddPatient(string fullname)
        {
            Patient p = new Patient() { FullName = fullname };
            await _databaseContext.Patients.AddAsync(p);
            await _databaseContext.SaveChangesAsync();
            return p;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Doctor> AddDoctor(string fullName)
        {
            Doctor d = new Doctor() { FullName = fullName };
            await _databaseContext.Doctors.AddAsync(d);
            await _databaseContext.SaveChangesAsync();
            return d;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(x => x.PatientId == id).ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.ToListAsync();
        }

        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await _databaseContext.Medicines.ToListAsync();
        }

        public async Task<IEnumerable<MedicinePrescription>> GetMedicinePrescriptions()
        {
            return await _databaseContext.MedPrescription.ToListAsync();
        }

        public async Task<Prescription> CreatePrescription(Prescription pres)
        {
            _databaseContext.Prescriptions.Add(pres);
            await _databaseContext.SaveChangesAsync();

            return pres;
        }

        public async Task<MedicinePrescription> CreateMedicinePrescription(MedicinePrescription preMed)
        {
            _databaseContext.MedPrescription.Add(preMed);
            await _databaseContext.SaveChangesAsync();

            return preMed;
        }
    }
}
