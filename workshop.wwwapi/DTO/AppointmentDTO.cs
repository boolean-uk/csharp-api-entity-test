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

        public PrescriptionforAppointmentDTO? prescription { get; set; }

        public AppointmentReturnDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            DoctorId = appointment.Doctor.Id;
            DoctorFullName = appointment.Doctor.FullName;
            PatientId = appointment.Patient.Id;
            PatientFullName = appointment.Patient.FullName;
            if (appointment.Prescription != null)
            {
                prescription = new PrescriptionforAppointmentDTO(appointment.Prescription);
            }
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

    public class PrescriptionforAppointmentDTO
    {
        private Prescription prescription;
        public List<MedicineDTO> Medicines { get; set; } = [];

        public PrescriptionforAppointmentDTO(Prescription prescription)
        {
            foreach (var medicine in prescription.Medicines)
            {

                Medicines.Add(new MedicineDTO(medicine));

            }
        }
    }

    public class MedicineDTO
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public int Quantity { get; set; }

        public MedicineDTO(Medicine medicine)
        {
            this.Name = medicine.Name;
            this.Note = medicine.Note;
            this.Quantity = medicine.Quantity;
        }
    }
}
