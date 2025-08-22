using workshop.wwwapi.DTOs.AppointmentDTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.PrescriptionDTO
{
    public static class PrescriptionExtension
    {
        public static PrescriptionGet ToDTO(this Prescription entity)
        {
            PrescriptionGet prescription = new PrescriptionGet();
            prescription.Id = entity.Id;
            prescription.Name = entity.Name;

            AppointmentGet appointment = new AppointmentGet();
            prescription.Appointment = appointment;
            prescription.Appointment.Id = entity.AppointmentId;
            prescription.Appointment.Booking = entity.Appointment.Booking;
            prescription.Appointment.Doctor.DoctorId = entity.Appointment.DoctorId;
            prescription.Appointment.Doctor.DoctorName = entity.Appointment.Doctor.FullName;
            prescription.Appointment.Patient.PatientId = entity.Appointment.PatientId;
            prescription.Appointment.Patient.PatientName = entity.Appointment.Patient.FullName;

            return prescription;
        }
    }
}
