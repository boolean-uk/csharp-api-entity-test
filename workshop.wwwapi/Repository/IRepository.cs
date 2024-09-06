﻿using workshop.wwwapi.Models;
using workshop.wwwapi.Models.InputObject;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task<Patient> CreatePatient(string fullname);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> CreateDoctor(string fullname);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentByIDs(int DocId, int PatId);
        Task<Appointment> CreateAppointment(InputAppointment input);

        Task<IEnumerable<Prescription>> GetPrescriptions();
        Task<Prescription> GetPrescriptionById(int id);
        Task<Prescription> CreatePrescription(IEnumerable<InputPrescription> medicines);
        Task<Appointment> AddPrescriptionToAppointment(int presID, int DocId, int PatId);
        Task<IEnumerable<Medicine>> GetMedicines();
        Task<Medicine> GetMedicineById(int id);
        Task<Medicine> CreateMedicine(string name);

    }
}
