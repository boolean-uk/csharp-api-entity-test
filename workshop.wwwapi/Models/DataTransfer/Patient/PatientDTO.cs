namespace workshop.wwwapi.Models.DataTransfer.Patient
{
    public class PatientDTO
    {
        public PatientDTO(Domain.Patient patient)
        {
            this.ID = patient.ID;
            this.FullName = patient.FullName;
        }
        public int ID { get; set; }
        public string FullName { get; set; }

    }
}
