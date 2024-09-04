using workshop.wwwapi.Models;

namespace workshop.wwwapi.Services
{
    public class DoctorDtoManager
    {
        public static OutputDoctor Convert(Doctor doctor)
        {
            return new OutputDoctor
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Appointments = AppointmentDtoManager.ConvertRemoveDoctor(doctor.Appointments)
            };
        }

        public static IEnumerable<OutputDoctor> Convert(IEnumerable<Doctor> doctors)
        {
            return doctors.Select(doctor => Convert(doctor));
        }

        public static Doctor Convert(InputDoctor inputDoctor)
        {
            return new Doctor
            {
                FullName = inputDoctor.FullName
            };
        }
    }
}
