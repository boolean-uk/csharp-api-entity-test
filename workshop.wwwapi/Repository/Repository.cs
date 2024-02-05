﻿using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }
        public async Task<IEnumerable<PatientDTO>> GetPatients()
        {
            return await _databaseContext.Patients.Select(x => new PatientDTO()
            {
                PatientId = x.Id,
                PatientName = x.FullName,
                Appointments = x.Appointments
                .Join(_databaseContext.Doctors,
                      appointment => appointment.DoctorId,
                      doctor => doctor.Id,
                      (appointment, doctor) => new PatientAppointmentDTO()
                      {
                          BookingTime = appointment.BookingTime,
                          DoctorId = appointment.DoctorId,
                          DoctorName = doctor.FullName,
                          AppointmentType = appointment.Type
                      })
                .ToList()
            }).ToListAsync();
        }

        public async Task<PatientDTO?> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Where(x => x.Id == id).Select(x => new PatientDTO()
            {
                PatientId = x.Id,
                PatientName = x.FullName,
                Appointments = x.Appointments
                .Join(_databaseContext.Doctors,
                      appointment => appointment.DoctorId,
                      doctor => doctor.Id,
                      (appointment, doctor) => new PatientAppointmentDTO()
                      {
                          BookingTime = appointment.BookingTime,
                          DoctorId = appointment.DoctorId,
                          DoctorName = doctor.FullName,
                          AppointmentType = appointment.Type
                      })
                .ToList()
            }).FirstOrDefaultAsync();
        }

        public async Task<PatientDTO?> CreatePatient(CreatePatientDTO cDTO)
        {
            Patient? dbPatient = await _databaseContext.Patients.Where(x => x.Id == cDTO.PatientId).FirstOrDefaultAsync();
            if (dbPatient != null) { return null; }
            Patient d = new() { Id = cDTO.PatientId, FullName = cDTO.PatientName, Appointments = [] };
            _databaseContext.Patients.Add(d);
            await _databaseContext.SaveChangesAsync();
            return new PatientDTO() { PatientId = d.Id, PatientName = d.FullName, Appointments = [] };
        }

        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            return await _databaseContext.Doctors.Select(x => new DoctorDTO()
            {
                DoctorId = x.Id,
                DoctorName = x.FullName,
                Appointments = x.Appointments
                .Join(_databaseContext.Patients,
                      appointment => appointment.PatientId,
                      patient => patient.Id,
                      (appointment, patient) => new DoctorAppointmentDTO()
                      {
                          BookingTime = appointment.BookingTime,
                          PatientId = appointment.PatientId,
                          PatientName = patient.FullName,
                          AppointmentType = appointment.Type
                      })
                .ToList()
            }).ToListAsync();
        }

        public async Task<DoctorDTO?> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Where(x => x.Id == id).Select(x => new DoctorDTO()
            {
                DoctorId = x.Id,
                DoctorName = x.FullName,
                Appointments = x.Appointments
                .Join(_databaseContext.Patients,
                      appointment => appointment.PatientId,
                      patient => patient.Id,
                      (appointment, patient) => new DoctorAppointmentDTO()
                      {
                          BookingTime = appointment.BookingTime,
                          PatientId = appointment.PatientId,
                          PatientName = patient.FullName,
                          AppointmentType = appointment.Type
                      })
                .ToList()
            }).FirstOrDefaultAsync();
        }
        public async Task<DoctorDTO?> CreateDoctor(CreateDoctorDTO cDTO)
        {
            Doctor? dbDoctor = await _databaseContext.Doctors.Where(x => x.Id == cDTO.DoctorId).FirstOrDefaultAsync();
            if (dbDoctor != null) { return null; }
            Doctor d = new() { Id = cDTO.DoctorId, FullName = cDTO.DoctorName, Appointments = [] };
            _databaseContext.Doctors.Add(d);
            await _databaseContext.SaveChangesAsync();
            return new DoctorDTO() { DoctorId = d.Id, DoctorName = d.FullName, Appointments = [] };
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointments()
        {
            return await _databaseContext.Appointments
                .Join(_databaseContext.Doctors,
                      appointment => appointment.DoctorId,
                      doctor => doctor.Id,
                      (appointment, doctor) => new { Appointment = appointment, DoctorName = doctor.FullName })
                .Join(_databaseContext.Patients,
                      combined => combined.Appointment.PatientId,
                      patient => patient.Id,
                      (combined, patient) => new AppointmentDTO()
                      {
                          DoctorId = combined.Appointment.DoctorId,
                          DoctorName = combined.DoctorName,
                          PatientId = combined.Appointment.PatientId,
                          PatientName = patient.FullName,
                          AppointmentType = combined.Appointment.Type
                      })
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatientId(int id)
        {
            return await _databaseContext.Appointments
                .Where(x => x.PatientId == id)
                .Join(_databaseContext.Doctors,
                      appointment => appointment.DoctorId,
                      doctor => doctor.Id,
                      (appointment, doctor) => new { Appointment = appointment, DoctorName = doctor.FullName })
                .Join(_databaseContext.Patients,
                      combined => combined.Appointment.PatientId,
                      patient => patient.Id,
                      (combined, patient) => new AppointmentDTO()
                      {
                          DoctorId = combined.Appointment.DoctorId,
                          DoctorName = combined.DoctorName,
                          PatientId = combined.Appointment.PatientId,
                          PatientName = patient.FullName,
                          AppointmentType = combined.Appointment.Type
                      })
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctorId(int id)
        {
            return await _databaseContext.Appointments
                .Where(x => x.PatientId == id)
                .Join(_databaseContext.Doctors,
                      appointment => appointment.DoctorId,
                      doctor => doctor.Id,
                      (appointment, doctor) => new { Appointment = appointment, DoctorName = doctor.FullName })
                .Join(_databaseContext.Patients,
                      combined => combined.Appointment.PatientId,
                      patient => patient.Id,
                      (combined, patient) => new AppointmentDTO()
                      {
                          DoctorId = combined.Appointment.DoctorId,
                          DoctorName = combined.DoctorName,
                          PatientId = combined.Appointment.PatientId,
                          PatientName = patient.FullName,
                          AppointmentType = combined.Appointment.Type
                      })
                .ToListAsync();
        }

        public async Task<AppointmentDTO?> GetAppointmentByIds(int doctorid, int patientid)
        {
            return await _databaseContext.Appointments
                .Where(x => x.PatientId == patientid && x.DoctorId == doctorid)
                .Join(_databaseContext.Doctors,
                      appointment => appointment.DoctorId,
                      doctor => doctor.Id,
                      (appointment, doctor) => new { Appointment = appointment, DoctorName = doctor.FullName })
                .Join(_databaseContext.Patients,
                      combined => combined.Appointment.PatientId,
                      patient => patient.Id,
                      (combined, patient) => new AppointmentDTO()
                      {
                          DoctorId = combined.Appointment.DoctorId,
                          DoctorName = combined.DoctorName,
                          PatientId = combined.Appointment.PatientId,
                          PatientName = patient.FullName,
                          AppointmentType = combined.Appointment.Type
                      })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PrescriptionDTO>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.Include(x => x.PrescriptionMedicines).Join(
                _databaseContext.Appointments,
                pres => new { pId = pres.AppointmentPatientId, dId = pres.AppointmentDoctorId },
                app => new { pId = app.PatientId, dId = app.DoctorId },
                (pres, app) => new PrescriptionDTO()
                {
                    Id = pres.Id,
                    Quantity = pres.Quantity,
                    MedicineInfo = pres.PrescriptionMedicines
                        .Join(_databaseContext.Medicines,
                            presmed => pres.Id,
                            med => med.Id,
                            (presmed, med) => new MedicineDTO() { Id = med.Id, Name = med.Name, Notes = med.Notes }
                        ).ToList(),
                    AppointmentDoctorId = app.DoctorId,
                    AppointmentPatientId = app.PatientId,
                    AppointmentBookingTime = app.BookingTime,
                    AppointmentType = app.Type
                })
                .ToListAsync();
        }

        public async Task<int> CreatePrescription(CreatePrescriptionDTO cDTO)
        {
            Appointment? dbAppointment = await _databaseContext.Appointments.Where(x => x.PatientId == cDTO.AppointmentPatientId && x.DoctorId == cDTO.AppointmentDoctorId).FirstOrDefaultAsync();
            if (dbAppointment == null) { return -1; }
            List<int> dbMedicines = await _databaseContext.Medicines.Where(x => cDTO.MedicineIds.Contains(x.Id)).Select(y => y.Id).ToListAsync();
            if (dbMedicines.Count == 0) { return -2; }
            Prescription p = new()
            {
                AppointmentDoctorId = dbAppointment.DoctorId,
                AppointmentPatientId = dbAppointment.PatientId,
                Quantity = cDTO.Quantity,
            };
            _databaseContext.Add(p);
            List<PrescriptionMedicine> presmeds = [];
            dbMedicines.ForEach(x =>
            {
                PrescriptionMedicine pm = new PrescriptionMedicine() { MedicineId = x, PrescriptionId = p.Id };
                presmeds.Add(pm);
                _databaseContext.Add(pm);
            });
            p.PrescriptionMedicines = presmeds;
            await _databaseContext.SaveChangesAsync();
            return 0;
        }
    }
}
