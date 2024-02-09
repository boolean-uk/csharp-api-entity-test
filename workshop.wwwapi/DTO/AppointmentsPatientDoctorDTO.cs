using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentsPatientDoctorDTO
    {
        public int Id { get; set; }
        public string Booking { get; set; }
        public PatientOnlyDTO Patient { get; set; }
        public List<DoctorsOnlyDTO> DoctorAppointments { get; set; }
        public ICollection<PrescriptionWithMedicineDTO> Prescriptions { get; set; }

        public AppointmentsPatientDoctorDTO(Appointment appointment)
        {
            Id = appointment.Id;
            Booking = appointment.Booking;
            Patient = new PatientOnlyDTO(appointment.Patient);
            DoctorAppointments = appointment.Doctor != null
                ? new List<DoctorsOnlyDTO> { new DoctorsOnlyDTO(appointment.Doctor) }
                : new List<DoctorsOnlyDTO>();

            Prescriptions = appointment.Prescriptions.Select(p =>  new PrescriptionWithMedicineDTO(p)).ToList();
        }
    }
}
