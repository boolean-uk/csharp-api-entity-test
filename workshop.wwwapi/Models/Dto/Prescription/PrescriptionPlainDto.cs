using workshop.wwwapi.Models.Dto.Appointment;

namespace workshop.wwwapi.Models.Dto.Prescription
{
    public class PrescriptionPlainDto
    {
        public int Id { get; set; }
        //public DateTimeOffset AppointmentBookingId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
