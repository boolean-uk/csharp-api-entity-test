using AutoMapper;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, PatientDTO>();
            CreateMap<Patient, PatientWithAppointmentsDTO>();
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<Doctor, DoctorWithAppointmentsDTO>();
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<Prescription, PrescriptionDTO>();
            CreateMap<Medicine, MedicineDTO>();
            CreateMap<MedicinePrescription, MedicinePrescriptionDTO>();
        }
    }
}
