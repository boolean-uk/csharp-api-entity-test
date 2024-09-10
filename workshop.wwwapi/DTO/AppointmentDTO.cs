using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDTO
    {
        public int Doctor_Id { get; set; }
        public int Patient_Id { get; set; }
        public DateTime BookingTime { get; set; }


        public static List<AppointmentDTO> CreateAppointmentDTO(List<Appointment> appointments)
        {
            List<AppointmentDTO> dtos = new List<AppointmentDTO>();

            foreach (Appointment appointment in appointments)
            {
                AppointmentDTO appointmentDTO = new AppointmentDTO();

                appointmentDTO.Doctor_Id = appointment.DoctorId;
                appointmentDTO.Patient_Id = appointment.PatientId;
                appointmentDTO.BookingTime = appointment.Booking;

                dtos.Add(appointmentDTO);
            }
            
            return dtos;
        }

    }
}
