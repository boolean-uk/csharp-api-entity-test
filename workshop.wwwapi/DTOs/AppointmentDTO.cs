using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Booking {  get; set; }
        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }
        public string AppointmentType { get; set; }

        public AppointmentDTO(Appointment a)
        {
            Id = a.Id;
            Booking = a.Booking;
            Doctor = new DoctorDTO(a.Doctor);
            Patient = new PatientDTO(a.Patient);
            AppointmentType = a.AppointmentType.ToString();
        }
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
