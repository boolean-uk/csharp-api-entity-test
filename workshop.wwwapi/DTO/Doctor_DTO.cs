using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class Doctor_DTO
    {
        public int id {  get; set; }

        public string FullName { get; set; }

        public List<Appointment_DTO> appointments { get; set; }

        public Doctor_DTO(Doctor doctor)
        {
            this.id = doctor.Id;
            this.FullName = doctor.FullName;
            this.appointments = new List<Appointment_DTO>();
            foreach(Appointment appointment in doctor.appointments)
            {
                this.appointments.Add(new Appointment_DTO(appointment));
            }
        }
    }
}
