using AutoMapper;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Mapper
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
