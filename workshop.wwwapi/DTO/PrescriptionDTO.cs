public class PrescriptionDTO
{
    public int Id { get; set; }

    public int AppointmentId { get; set; }

    public string PatientName { get; set; }

    public List<PrescriptionMedicineDTO> Medicines { get; set; }


}