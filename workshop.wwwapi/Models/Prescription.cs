using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    //prescription
    [Table("prescriptions")]
    public class Prescription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("appointment_id")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public ICollection<MedicinePrescription> 
            medicinePrescriptions { get; set; }
    }

    //DTO
    public class PrescriptionsResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AppointmentId { get; set;}
        public string DoctorsName { get; set; }
        public string PatientsName { get; set; }
        public List<MedicineInPrescriptionDTO> 
            medicineInPrescriptionDTO { get; set; }
        

        public PrescriptionsResponseDTO(Prescription prescription)
        {
            Id = prescription.Id;
            Name = prescription.Name;
            AppointmentId = prescription.AppointmentId;
            DoctorsName = prescription.Appointment.Doctor.FullName;
            PatientsName = prescription.Appointment.Patient.FullName;


            medicineInPrescriptionDTO = new List<MedicineInPrescriptionDTO>();

            foreach(var medicine in prescription.medicinePrescriptions)
            {
                MedicineInPrescriptionDTO medicin = 
                    new MedicineInPrescriptionDTO(medicine);
                medicineInPrescriptionDTO.Add(medicin);
            }
        }
    }
}
