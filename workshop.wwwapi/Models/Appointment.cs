using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly

    [Table("appointments")]
    //[PrimaryKey(nameof(DoctorId), nameof(PatientId))]
    public class Appointment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("booking_datetime")]
        public DateTime Booking { get; set; }

        //[Key]

        [Column("doctor_id")]
        public int DoctorId { get; set; }

        //[Key]

        [Column("patient_id")]
        public int PatientId { get; set; }



        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }

        public Appointment(AppointmentPost model)
        {
            Booking = model.Booking;
            DoctorId = model.DoctorId;
            PatientId = model.PatientId;
        }
        public Appointment()
        {

        }



        public List<AppointmentGet> ToAppointmentGets(List<Appointment> appointments)
        {
            List<AppointmentGet> result = new List<AppointmentGet>();
            foreach (Appointment appointment in appointments)
            {
                result.Add(new AppointmentGet(appointment));
            }

            return result;
        }
    }
}
