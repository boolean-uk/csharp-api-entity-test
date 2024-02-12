using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("prescriptions")]
    public class Prescription
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("doctor_id")]
        public int AppointmentDoctorId { get; set; }

        [Column("patient_id")]
        public int AppointmentPatientId { get; set; }

        public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; }

        [ForeignKey("AppointmentDoctorId,AppointmentPatientId")]
        public Appointment Appointment { get; set; }

        public PrescriptionDto ToDto()
        {
            return new PrescriptionDto
            {
                Appointment = Appointment.ToDto(),
                Medicines = MedicinePrescriptions.Select(mp => mp.ToDataDto()).ToList()
            };
        }
    }

    public struct PrescriptionDto
    {
        public AppointmentDto Appointment { get; set; }
        public List<MPDataDto> Medicines { get; set; }
    }

    public struct PrescriptionInput
    {
        public List<MPInputDto> medicines { get; set; }

    }
}
