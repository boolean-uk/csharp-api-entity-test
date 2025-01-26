using AutoMapper;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDTO>();
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<Appointment, AppointmentDTO>();
            
        }
    }
}
