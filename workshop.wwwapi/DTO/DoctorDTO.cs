using System.Text.Json.Serialization;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class doctorDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<DoctorAppointmentDTO> doctorAppointmentDTOs { get; set; }
        public doctorDTO(Doctor doctor)
        {
            id = doctor.Id;
            name = doctor.FullName;

            //more later

            doctorAppointmentDTOs = new List<DoctorAppointmentDTO>();

            var list = doctor.Appointments;
            if(list != null)
            {

                foreach (var item in list)
                {
                    DoctorAppointmentDTO doctorAppointmentDTO = new DoctorAppointmentDTO(item);
                    doctorAppointmentDTOs.Add(doctorAppointmentDTO);
                }
            }



        }
        [JsonConstructor]
        public doctorDTO()
        {
            
        }
    }
}
