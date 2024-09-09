using workshop.wwwapi.Models;

namespace workshop.wwwapi.ViewModel
{
    public class AppointmentDTO
    {
        public int appointmentId { get; set; }
        public DateTime date {  get; set; }
        public int patientId { get; set; }
        public string patientName { get; set; }
        public int doctorId { get; set; }
        public string doctorName { get; set; }

        public AppointmentDTO(Appointment appointment, List<Patient> patients, List<Doctor> doctors)
        {
            this.appointmentId = appointment.Id;
            this.date = appointment.Booking;
            var patient = patients.Where(p => p.Id == appointment.PatientId).FirstOrDefault();

            var doctor = doctors.Where(d => d.Id == appointment.DoctorId).FirstOrDefault();

            if (doctor != null && patient != null)
            {
                this.patientId = patient.Id;
                this.patientName = patient.FullName;
                this.doctorId = doctor.Id;
                this.doctorName = doctor.FullName;
            }
        }
    }
}
