using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class PatientDTO
    {
        public PatientDTO(Patient p) {
            this.Id = p.Id;
            this.Name = p.FullName;
        }
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class PatientsAppointmentsDTO
    {
        public PatientsAppointmentsDTO(Patient p)
        {
            this.Name = p.FullName;
            foreach(var appointment in p.Appointments)
            {
                Appointments.Add(new AppointmentWithDoctorsDTO(appointment));
            }
        }
        public string Name { get; set; }
        public List<AppointmentWithDoctorsDTO> Appointments { get; set; } = new List<AppointmentWithDoctorsDTO>();
    }
}
