using workshop.wwwapi.Models;

namespace wwwapi.DTO
{
    public class AppointmentReturnDTO
    {

        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public int PatientId { get; set; }
        public string PatientFullName { get; set; }

        public AppointmentReturnDTO(Appointment appointment)
        {

            Booking = appointment.Booking;
            DoctorId = appointment.Doctor.Id;
            DoctorFullName = appointment.Doctor.FullName;
            PatientId = appointment.Patient.Id;
            PatientFullName = appointment.Patient.FullName;
        }

        public static List<AppointmentReturnDTO> ListOfAppointments(List<Appointment> appointments)
        {
            List<AppointmentReturnDTO> appointmentReturnDTOs = new List<AppointmentReturnDTO>();
            foreach (Appointment appointment in appointments)
            {
                appointmentReturnDTOs.Add(new AppointmentReturnDTO(appointment));
            }
            return appointmentReturnDTOs;
        }
    }
}