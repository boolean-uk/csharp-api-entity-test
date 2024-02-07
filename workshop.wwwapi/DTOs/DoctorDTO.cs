using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class DoctorDTO
    {
        public DoctorDTO(Doctor d)
        {
            Id = d.Id;
            Name = d.FullName;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DoctorsAppointmentsDTO
    {
        public DoctorsAppointmentsDTO(Doctor d) {
            this.Name = d.FullName;
            foreach(var appointment in d.Appointments)
            {
                this.Appointments.Add(new AppointmentWithPatientsDTO(appointment));
            }
        }
        public string Name { get; set; }
        public List<AppointmentWithPatientsDTO> Appointments { get; set; } = new List<AppointmentWithPatientsDTO>();

    }

}
