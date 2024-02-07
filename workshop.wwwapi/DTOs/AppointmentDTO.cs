using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Booking {  get; set; }
        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }
    }

    public class AppointmentWithPatientsDTO
    {
        public AppointmentWithPatientsDTO(Appointment a) {
            this.Booking = a.Booking;
            this.Patient = new PatientDTO(a.Patient);
        }
        public DateTime Booking { get; set; }
        public PatientDTO Patient { get; set; }
    }

    public class AppointmentWithDoctorsDTO
    {
        public AppointmentWithDoctorsDTO(Appointment a)
        {
            this.Booking = a.Booking;
            this.Doctor = new DoctorDTO(a.Doctor);
        }
        public DateTime Booking { get; set; }
        public DoctorDTO Doctor { get; set; }
    }

}
