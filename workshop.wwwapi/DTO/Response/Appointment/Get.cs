
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.DTO.Response.Appointment
{
    public class Get : BaseDTO<Get,Models.Appointment>
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public override void define_include_queries(ref List<Func<IQueryable<Models.Appointment>, IQueryable<Models.Appointment>>> queryLambda)
        {
            queryLambda.Add( x => x.Include(x => x.Doctor).Include(x => x.Patient));
        }

        public override void define_where_query_for_id(ref Func<IQueryable<Models.Appointment>, IQueryable<Models.Appointment>> id_query, params object[] id)
        {
            id_query = x => x.Where(x => x.DoctorId == (int)id[0] && x.PatientId == (int)id[1]);
        }

        public override void Instantiate(Models.Appointment instance)
        {
            Booking = instance.Booking;
            DoctorId = instance.DoctorId;
            PatientId = instance.PatientId;
            DoctorName = instance.Doctor.FullName;
            PatientName = instance.Patient.FullName;
        }
    }

}
