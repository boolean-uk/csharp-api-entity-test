using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Data.DTO;
using workshop.wwwapi.Data.Enums;

namespace workshop.wwwapi.Models
{

    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    [PrimaryKey(nameof(DoctorId), nameof(PatientId))]
    public class Appointment
    {
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [Column("booking_date")]
        public DateTime Booking { get; set; }
        [Column("appointment_type")]
        public AppointmentType AppointmentType { get; set; }

        public AppointmentDoctorDTO ToDoctorDTO()
        {
            return new AppointmentDoctorDTO
            {
                PatientId = PatientId,
                PatientName = Patient.FullName,
                Booking = Booking,
                AppointmentType = AppointmentType.ToString()
            };
        }

        public AppointmentPatientDTO ToPatientDTO()
        {
            return new AppointmentPatientDTO
            {
                DoctorId = DoctorId,
                DoctorName = Doctor.FullName,
                Booking = Booking,
                AppointmentType = AppointmentType.ToString()
            };
        }

        public AppointmentResponseDTO ToResponseDTO()
        {
            return new AppointmentResponseDTO
            {
                PatientId = PatientId,
                PatientName = Patient.FullName,
                DoctorId = DoctorId,
                DoctorName = Doctor.FullName,
                Booking = Booking,
                AppointmentType = AppointmentType.ToString()
            };
        }

    }
}
