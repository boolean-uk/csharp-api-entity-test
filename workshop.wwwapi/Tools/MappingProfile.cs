using AutoMapper;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorView>();
            CreateMap<Doctor, DoctorInternal>();

            CreateMap<Patient, PatientView>();
            CreateMap<Patient, PatientInternal>();

            CreateMap<Appointment, AppointmentView>().ForMember(dest => dest.AppointmentType,
                   opt => opt.MapFrom(src => src.AppointmentType.ToString())); ;
            CreateMap<Appointment, AppointmentInternal>().ForMember(dest => dest.AppointmentType,
                   opt => opt.MapFrom(src => src.AppointmentType.ToString())); ;
            CreateMap<Appointment, AppointmentPatient>().ForMember(dest => dest.AppointmentType,
                   opt => opt.MapFrom(src => src.AppointmentType.ToString())); ;
            CreateMap<Appointment, AppointmentDoctor>().ForMember(dest => dest.AppointmentType,
                   opt => opt.MapFrom(src => src.AppointmentType.ToString())); ;
            CreateMap<Appointment, AppointmentDoctorPatient>().ForMember(dest => dest.AppointmentType,
                opt => opt.MapFrom(src => src.AppointmentType.ToString())); ;

            CreateMap<Prescription, PrescriptionView>();
            CreateMap<Prescription, PrescriptionInternal>();

            CreateMap<Medicine, MedicineView>();
            CreateMap<Medicine, MedicineInternal>();
        }
    }
}
