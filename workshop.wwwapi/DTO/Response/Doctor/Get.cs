using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO.Response.Doctor
{
    public class Get : BaseDTO<Get,Models.Doctor>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<DTO.Response.Appointment.Get> appointments { get; set; }

        public override void define_include_queries(ref List<Func<IQueryable<Models.Doctor>, IQueryable<Models.Doctor>>> queryLambda)
        {
            queryLambda.Add(x => x.Include(x => x.Appointments).ThenInclude(x => x.Patient));
        }

        public override void define_where_query_for_id(ref Func<IQueryable<Models.Doctor>, IQueryable<Models.Doctor>> id_query, params object[] id)
        {
            id_query = x => x.Where(x => x.Id == (int)id[0]);
        }

        public override void Instantiate(Models.Doctor instance)
        {
            this.Id = instance.Id;
            this.FullName = instance.FullName;
            //this.appointments = instance.Appointments.Select(x => new Appointment.Get(x)).ToList();
            this.appointments = ToDTOs<Models.Appointment,Appointment.Get>(instance.Appointments).ToList();
        }
    }
}
