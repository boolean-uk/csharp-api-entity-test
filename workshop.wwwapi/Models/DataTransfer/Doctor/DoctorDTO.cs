namespace workshop.wwwapi.Models.DataTransfer.Doctor
{
    public class DoctorDTO
    {
        public DoctorDTO(Domain.Doctor doctor)
        {
            this.ID = doctor.ID;
            this.FullName = doctor.FullName;
        }
        public int ID { get; set; }
        public string FullName { get; set; }
    }
}
