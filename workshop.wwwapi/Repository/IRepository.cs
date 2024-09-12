﻿using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task<Patient> AddPatient(string fullname);


        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> AddDoctor(string fullName);

        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);

        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<IEnumerable<Medicine>> GetMedicines();
        Task<IEnumerable<MedicinePrescription>> GetMedicinePrescriptions();
        Task<Prescription> CreatePrescription(Prescription pres);
        Task<MedicinePrescription> CreateMedicinePrescription(MedicinePrescription preMed);



    }
}
