using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDTO
    {


        public DateTime datetime { get; set; }
        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public string DoctorName { get; set; }
        public string PatientName { get; set; }

        public AppointmentDTO() { }

        public AppointmentDTO(Appointment appointment)
        {
            DoctorId = appointment.DoctorId;
            PatientId = appointment.PatientId;
            datetime = appointment.Booking;

            DoctorName = appointment.Doctor.FullName;
            PatientName = appointment.Patient.FullName;
        }


    }
}
