using AutoMapper;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<Patient, PatientDTO>();
            CreateMap<Appointment, AppointmentDTO>();
        }
    }
}
