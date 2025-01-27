using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO.Response.Appointment
{
    public class GetDoctors : BaseDTO<GetDoctors, Models.Doctor>
    {
        public List<Appointment.Get> Appointments { get; set; } = new List<Appointment.Get>();

        public override void define_include_queries(ref List<Func<IQueryable<Models.Doctor>, IQueryable<Models.Doctor>>> queryLambda)
        {
            queryLambda.Add( x => x.Include(x => x.Appointments).ThenInclude(x => x.Patient));
        }

        public override void define_where_query_for_id(ref Func<IQueryable<Models.Doctor>, IQueryable<Models.Doctor>> id_query,params object[] id)
        {
            id_query = x => x.Where(x => x.Id == (int)id[0]);
        }

        public override void Instantiate(Models.Doctor instance)
        {
            Appointments = ToDTOs<Models.Appointment, Appointment.Get>(instance.Appointments).ToList();
        }
    }
}
