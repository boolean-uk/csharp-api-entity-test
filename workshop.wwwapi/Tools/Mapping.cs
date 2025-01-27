using AutoMapper;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace workshop.wwwapi.Tools

{
    public class Mapping : Profile
    {

        public Mapping()
        {
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<Patient, PatientDTO>();
            CreateMap<Appointment, AppointmentPatientDTO>()
                 .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName));

            CreateMap<Appointment, AppointmentDoctorDTO>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName));

        }
    }
}
