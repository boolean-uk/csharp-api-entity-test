using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace workshop.wwwapi.DTO.Response.Medicine
{
    public class Get : BaseDTO<Get, Models.Medicine>
    {
        public override void Instantiate(Models.Medicine instance)
        {
            this.Id = instance.Id;
            this.name = instance.name;
        }

        public int Id { get; set; }
        public string name { get; set; }

        public override void define_include_queries(ref List<Func<IQueryable<Models.Medicine>, IQueryable<Models.Medicine>>> queryLambda)
        {
            //queryLambda = x => x.Include(x => x.Appointments).
            //        ThenInclude(x => x.Doctor);

        }
        public override void define_where_query_for_id(ref Func<IQueryable<Models.Medicine>, IQueryable<Models.Medicine>> id_query, params object[] id)
        {
            queryLambda_where_id = x => x.Where(x => x.Id == (int)id[0]);
        }

    }
}
