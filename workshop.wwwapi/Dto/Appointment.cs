using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository;

public class AppointmentPostDto
{
    public DateTime Booking { get; set; }

    public AppointmentType AppointmentType { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
}

public class AppointmentGetDto
{
    public DateTime Booking { get; set; }

    public int PatientId { get; set; }
    public PatientShallow Patient { get; set; }

    public AppointmentType AppointmentType { get; set; }

    public int DoctorId { get; set; }
    public DoctorShallow Doctor { get; set; }

    public AppointmentGetDto() { }

    public AppointmentGetDto(Appointment appointment)
    {
        this.Booking = appointment.Booking;
        this.PatientId = appointment.PatientId;
        this.Patient = new PatientShallow(appointment.Patient);
        this.DoctorId = appointment.DoctorId;
        this.Doctor = new DoctorShallow(appointment.Doctor);
    }
}

public class AppointmentWithoutDoctor
{
    public DateTime Booking { get; set; }

    public int PatientId { get; set; }
    public PatientShallow Patient { get; set; }

    public AppointmentType AppointmentType { get; set; }

    public AppointmentWithoutDoctor() { }

    public AppointmentWithoutDoctor(Appointment appointment)
    {
        this.Booking = appointment.Booking;
        this.PatientId = appointment.PatientId;
        this.Patient = new PatientShallow(appointment.Patient);
    }
}

public class AppointmentWithoutPatient
{
    public DateTime Booking { get; set; }
    public int DoctorId { get; set; }
    public DoctorShallow Doctor { get; set; }

    public AppointmentWithoutPatient() { }

    public AppointmentType AppointmentType { get; set; }

    public AppointmentWithoutPatient(Appointment appointment)
    {
        this.Booking = appointment.Booking;
        this.DoctorId = appointment.DoctorId;
        this.Doctor = new DoctorShallow(appointment.Doctor);
    }
}
