using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO.Response.Appointment
{
    public class GetPatients : BaseDTO<GetPatients, Models.Patient>
    {
        public List<Appointment.Get> Appointments { get; set; } = new List<Appointment.Get>();

        public override void define_include_queries(ref List<Func<IQueryable<Models.Patient>, IQueryable<Models.Patient>>> queryLambda)
        {
            queryLambda.Add( x => x.Include(x => x.Appointments).ThenInclude(x => x.Doctor));
        }

        public override void define_where_query_for_id(ref Func<IQueryable<Models.Patient>, IQueryable<Models.Patient>> id_query, params object[] id)
        {
            id_query = x => x.Where(x => x.Id == (int)id[0]);
        }

        public override void Instantiate(Models.Patient instance)
        {
            Appointments = ToDTOs<Models.Appointment, Appointment.Get>(instance.Appointments).ToList();
        }
    }
}
