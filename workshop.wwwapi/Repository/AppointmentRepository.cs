﻿using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{

    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private DatabaseContext _databaseContext;
        private readonly DbSet<Appointment> _dbSet;
        public AppointmentRepository(DatabaseContext db) : base (db)
        {
            _databaseContext = db;
            _dbSet = db.Set<Appointment>();
        }

        public async Task<List<Appointment>> getAppointmentByDoctor(int doctorId)
        {
            return await _databaseContext.Appointments
                    .Where(a => a.DoctorId == doctorId)
                    .Include(a => a.doctor)
                    .Include(a => a.patient)
                    .ToListAsync(); 
        }

        public async Task<List<Appointment>> getAppointmentByPatient(int patientId)
        {
            return await _databaseContext.Appointments
                      .Where(a => a.PatientId == patientId)
                      .Include(a => a.doctor)  
                      .Include(a => a.patient)
                      .ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments
                      .Include(a => a.doctor)
                      .Include(a => a.patient)
                      .ToListAsync();
        }

    }
}
