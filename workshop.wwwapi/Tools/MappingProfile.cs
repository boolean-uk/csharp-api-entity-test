using System;
using AutoMapper;
using workshop.wwwapi.Models;
using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Tools;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Patient, PatientDTO>();
        CreateMap<Appointment, AppointmentDTO>();
        CreateMap<Doctor, DoctorDTO>();
        CreateMap<PatientPost, Patient>();
        CreateMap<DoctorPost, Doctor>();
        CreateMap<AppointmentPost, Appointment>();
    }
}
