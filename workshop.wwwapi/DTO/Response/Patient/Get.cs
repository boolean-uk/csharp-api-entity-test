using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace workshop.wwwapi.DTO.Response.Patient
{
    public class Get : BaseDTO<Get, Models.Patient>
    {
        public override void Instantiate(Models.Patient instance)
        {
            this.Id = instance.Id;
            this.FullName = instance.FullName;
            this.appointments = ToDTOs<Models.Appointment, Appointment.Get>(instance.Appointments).ToList();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<DTO.Response.Appointment.Get> appointments { get; set; }

        public override void define_include_queries(ref List<Func<IQueryable<Models.Patient>, IQueryable<Models.Patient>>> queryLambda)
        {
            queryLambda.Add(x => x.Include(x => x.Appointments).
                    ThenInclude(x => x.Doctor));

        }
        public override void define_where_query_for_id(ref Func<IQueryable<Models.Patient>, IQueryable<Models.Patient>> id_query, params object[] id)
        {
            queryLambda_where_id = x => x.Where(x => x.Id == (int)id[0]);
        }

    }
}
