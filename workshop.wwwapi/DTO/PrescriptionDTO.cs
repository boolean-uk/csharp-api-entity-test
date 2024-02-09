using workshop.wwwapi.Models;

namespace wwwapi.DTO
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public int? AppointmentId { get; set; }
        public AppointmentForPrescriptionDTO Appointment { get; set; }
        public List<MedicineDTO> Medicines { get; set; } = new List<MedicineDTO>();

        public PrescriptionDTO(Prescription prescription)
        {
            Id = prescription.Id;
            AppointmentId = prescription.AppointmentId;
            if (prescription.Appointment != null)
            {
                Appointment = new AppointmentForPrescriptionDTO(prescription.Appointment);
            }
            foreach (var medicine in prescription.Medicines)
            {
                Medicines.Add(new MedicineDTO(medicine));
            }
        }

        public static List<PrescriptionDTO> FromList(List<Prescription> prescriptions)
        {
            return prescriptions.Select(p => new PrescriptionDTO(p)).ToList();

        }
    }



    public class AppointmentForPrescriptionDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public int PatientId { get; set; }
        public string PatientFullName { get; set; }

        public AppointmentForPrescriptionDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            DoctorId = appointment.Doctor.Id;
            DoctorFullName = appointment.Doctor.FullName;
            PatientId = appointment.Patient.Id;
            PatientFullName = appointment.Patient.FullName;
        }
    }
}
