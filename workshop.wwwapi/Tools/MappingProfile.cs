using AutoMapper;
using workshop.wwwapi.DTO.Responses;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<Course, CourseDTO>();
            CreateMap<Office, OfficeDTO>();
            
        }
    }
}
