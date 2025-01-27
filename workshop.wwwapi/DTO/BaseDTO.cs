using System.Linq.Expressions;
using workshop.wwwapi.DTO.Request.Appointment;
using workshop.wwwapi.DTO.Response.Patient;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Interface;
using workshop.wwwapi.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace workshop.wwwapi.DTO
{
    public abstract class BaseDTO<DTO_type, Model_type>
        where DTO_type : BaseDTO<DTO_type, Model_type>, new()
        where Model_type : class, ICustomModel
    {
        protected BaseDTO(){}
        public List<Func<IQueryable<Model_type>, IQueryable<Model_type>>> queryLambda_includes = new();
        public Func<IQueryable<Model_type>, IQueryable<Model_type>> queryLambda_where_id;

        public static async Task<List<DTO_type>>  DTO(IRepository<Model_type> repo)
        {
            var a = new DTO_type();
            a.define_include_queries(ref a.queryLambda_includes);

            var instances = await a.DefineIncludes_multi(repo);
            var dtos = instances.Select(x => { var n = new DTO_type(); n.Instantiate(x); return n; }).ToList();

            return dtos;
        }
        public static async Task<DTO_type> DTO(IRepository<Model_type> repo, params object[] id)
        {
            var a = new DTO_type();
            a.define_include_queries(ref a.queryLambda_includes);
            a.define_where_query_for_id(ref a.queryLambda_where_id, id);
            var instance = await a.DefineIncludes_single(repo, id);
            if (instance == null) throw new KeyNotFoundException();
            a.Instantiate(instance);
            return a;
        }

        public static B ToDTO<A,B>(A input)
            where B : BaseDTO<B, A>, new()
            where A : class, ICustomModel
        {
            var b = new B();
            b.Instantiate(input);
            return b;
        }
        public static IEnumerable<B> ToDTOs<A,B>(IEnumerable<A> input)
            where B : BaseDTO<B, A>, new()
            where A : class, ICustomModel
        {
            List<B> dto_list = new();
            foreach (var a in input)
            {
                var b = new B();
                b.Instantiate(a);
                dto_list.Add(b);
            }
            
            return dto_list;
        }

        private async Task<Model_type> DefineIncludes_single(IRepository<Model_type> repo, object id)
        {
            return await repo.GetEntry(  queryLambda_where_id, queryLambda_includes.ToArray());
        }
        private async Task<IEnumerable<Model_type>> DefineIncludes_multi(IRepository<Model_type> repo)
        {
            //return await repo.GetEntries([queryLambda_includes]);
            return await repo.GetEntries(queryLambda_includes.ToArray());
        }

        public abstract void define_include_queries(ref List<Func<IQueryable<Model_type>, IQueryable<Model_type>>> queryLambda);
        public abstract void define_where_query_for_id(ref Func<IQueryable<Model_type>, IQueryable<Model_type>> id_query, params object[] id);
        public abstract void  Instantiate(Model_type instance);

        
    }
}
