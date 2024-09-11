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

        public async Task<Patient> GetAEnitityById(int id)
        {
            return await _databaseContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.ToListAsync();
        }

        public async Task<Doctor> MakeDoctor(Doctor doctor)
        {
            await _databaseContext.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Patient> MakePatient(Patient patient)
        {
            await _databaseContext.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }


        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId == id).ToListAsync();
        }
    }
}
