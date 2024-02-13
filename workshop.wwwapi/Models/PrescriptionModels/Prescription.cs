using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Models.PrescriptionMedicineModels;

namespace workshop.wwwapi.Models.PrescriptionModels
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public int AppointmentDoctorId { get; set; }
        public int AppointmentPatientId { get; set; }
        public DateTime AppointmentBooking { get; set; }
        public Appointment Appointment { get; set; }
        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();
    }

}
