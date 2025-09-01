using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data;

public class Seeder
{
    public List<Doctor> Doctors { get; init; } = [];
    public List<Patient> Patients { get; init; } = [];
    public List<Appointment> Appointments { get; init; } = [];

    public Seeder()
    {
        Doctors.AddRange([
            new Doctor{FullName = "John Doe", Id = 1 },
            new Doctor{FullName = "Dr. Mario", Id = 2 },
            new Doctor{FullName = "Karel Bibber", Id = 3 },
        ]);

        Patients.AddRange([
            new Patient{FullName = "Henk Patient", Id = 1 },
            new Patient{FullName = "Kees Kanon", Id = 2 },
            new Patient{FullName = "Michael Mank", Id = 3 },
        ]);

        Appointments.AddRange([
            new Appointment()
            {
                Booking = new DateTime(2025, 3, 20, 16, 15, 0).ToUniversalTime(),
                DoctorId = Doctors[0].Id,
                PatientId = Patients[0].Id,
                Id = 1,
            },
            new Appointment()
            {
                Booking = new DateTime(200, 3, 20, 4, 15, 0).ToUniversalTime(),
                DoctorId = Doctors[1].Id,
                PatientId = Patients[0].Id,
                Id = 2,
            },
            new Appointment()
            {
                Booking = new DateTime(2023, 3, 20, 16, 15, 0).ToUniversalTime(),
                DoctorId = Doctors[2].Id,
                PatientId = Patients[1].Id,
                Id = 3,
            },
            new Appointment()
            {
                Booking = new DateTime(2000, 3, 20, 16, 15, 0).ToUniversalTime(),
                DoctorId = Doctors[1].Id,
                PatientId = Patients[2].Id,
                Id = 4,
            }
        ]);
    }
}