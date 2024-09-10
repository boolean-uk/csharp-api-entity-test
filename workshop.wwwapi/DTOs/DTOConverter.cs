using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public static class DTOConverter
    {
        public static IEnumerable<DTOPerson> DTOPeopleListConverter(this IEnumerable<Patient> list) 
        {
            return list.Select(p => new DTOPerson { Id = p.Id, FullName = p.FullName, Appointments = p.Appointments });
        }
        public static IEnumerable<DTOPerson> DTOPeopleListConverter(this IEnumerable<Doctor> list)
        {
            return list.Select(p => new DTOPerson { Id = p.Id, FullName = p.FullName, Appointments = p.Appointments });
        }

        public static DTOPerson DTOPersonConverter(this Patient patient)
        {
            return new DTOPerson {Id = patient.Id, FullName = patient.FullName, Appointments = patient.Appointments};
        }
        public static DTOPerson DTOPersonConverter(this Doctor patient)
        {
            return new DTOPerson { Id = patient.Id, FullName = patient.FullName, Appointments = patient.Appointments };
        }

        public static DTOAppointment DTOAppointmentConverter(this Appointment appointment) {
            return new DTOAppointment { Booking = appointment.Booking, DoctorId = appointment.DoctorId, PatientId = appointment.PatientId };
        }

        public static IEnumerable<DTOAppointment> DTOAppointmentListConverter(this IEnumerable<Appointment> list)
        {
            return list.Select(p => new DTOAppointment {Booking = p.Booking, DoctorId = p.DoctorId, PatientId = p.PatientId });
        }
    }


}
