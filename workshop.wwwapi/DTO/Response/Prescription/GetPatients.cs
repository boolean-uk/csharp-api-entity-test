using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO.Response.Prescription
{
    public class GetPatients : BaseDTO<GetPatients, Models.Patient>
    {
        public List<Prescription.Get> Prescriptions { get; set; } = new List<Prescription.Get>();

        public override void define_include_queries(ref List<Func<IQueryable<Models.Patient>, IQueryable<Models.Patient>>> queryLambda)
        {
            queryLambda.Add(
                x => x.Include(x => x.Prescriptions)
                .ThenInclude(x => x.Doctor)
                );
            queryLambda.Add(
                x => x.Include(x => x.Prescriptions).
                ThenInclude(x => x.MedicinesInPrescription).
                ThenInclude(x => x.Medicine)
                );
        
        }

        public override void define_where_query_for_id(ref Func<IQueryable<Models.Patient>, IQueryable<Models.Patient>> id_query, params object[] id)
        {
            id_query = x => x.Where(x => x.Id == (int)id[0]);
        }

        public override void Instantiate(Models.Patient instance)
        {
            Prescriptions = ToDTOs<Models.Prescription, Prescription.Get>(instance.Prescriptions).ToList();
        }
    }
}
