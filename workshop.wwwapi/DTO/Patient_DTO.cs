using workshop.wwwapi.Models;
namespace workshop.wwwapi.DTO
{
    public class Patient_DTO
    {
        public Patient_DTO(Patient pasient)
        {
            this.FullName = pasient.FullName;
            this.Id = pasient.Id;
            this.appointments = new List<Appointment_DTO>();
            foreach(Appointment appointment in pasient.appointments)
            {
                this.appointments.Add(new Appointment_DTO(appointment));
            }
        }
        public int Id { get; set; }

        public string FullName { get; set; }

        public List<Appointment_DTO> appointments { get; set; }

    }
}
