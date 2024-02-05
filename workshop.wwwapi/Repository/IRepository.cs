using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAnAppointment(int id1, int id2);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id);
        Task<Patient> GetPatient(int? id);
        Task<Doctor> GetADoctor(int? id);
        Task<Doctor> AddDoctor(InnDoctorDTO newDoctor);
        Task<IEnumerable<Prescription>> Getprescriptions();
        Task<Prescription> AddPrescription(InPrescriptionDTO newPrescription);
    }
}
