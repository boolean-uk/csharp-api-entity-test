using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{

    public class AppointmentDTO
    {
        public DateTime Booking { get; set; }

        public string Type { get; set; }
        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }

        public PrescriptionDTO Prescription { get; set; }
        public AppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            Type = appointment.Type;
            Doctor = new DoctorDTO(appointment.Doctor);
            Patient = new PatientDTO(appointment.Patient);
            Prescription = new PrescriptionDTO(appointment.Prescription);
        }
    }



       
}