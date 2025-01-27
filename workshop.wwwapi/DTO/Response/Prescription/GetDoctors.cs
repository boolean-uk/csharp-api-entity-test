using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO.Response.Prescription
{
    public class GetDoctors : BaseDTO<GetDoctors, Models.Doctor>
    {
        public List<Prescription.Get> Prescriptions { get; set; } = new List<Prescription.Get>();

        public override void define_include_queries(ref List<Func<IQueryable<Models.Doctor>, IQueryable<Models.Doctor>>> queryLambda)
        {
            queryLambda.Add(
                x => x.Include(x => x.Prescriptions)
                .ThenInclude(x => x.Patient)
                );
            queryLambda.Add(
                x => x.Include(x => x.Prescriptions).
                ThenInclude(x => x.MedicinesInPrescription).
                ThenInclude(x => x.Medicine)
                );
        }

        public override void define_where_query_for_id(ref Func<IQueryable<Models.Doctor>, IQueryable<Models.Doctor>> id_query,params object[] id)
        {
            id_query = x => x.Where(x => x.Id == (int)id[0]);
        }

        public override void Instantiate(Models.Doctor instance)
        {
            Prescriptions = ToDTOs<Models.Prescription, Prescription.Get>(instance.Prescriptions).ToList();
        }
    }
}
