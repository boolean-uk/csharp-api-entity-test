using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace workshop.wwwapi.DTO.Response.MedicinesInPrescription
{
    public class Get : BaseDTO<Get, Models.MedicinesInPrescription>
    {
        public override void Instantiate(Models.MedicinesInPrescription instance)
        {
            this.MedicineId = instance.MedicineId;
            this.MedicineName = instance.Medicine.name;
            this.PrescriptionId = instance.PrescriptionId;
            this.note = instance.note;
            this.quantity = instance.quantity;
        }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int PrescriptionId { get; set; }
        public int quantity { get; set; }
        public string note { get; set; }


        public override void define_include_queries(ref List<Func<IQueryable<Models.MedicinesInPrescription>, IQueryable<Models.MedicinesInPrescription>>> queryLambda)
        {
            queryLambda.Add( x => x.Include(x => x.Medicine).
                    Include(x => x.Prescription));

        }
        public override void define_where_query_for_id(ref Func<IQueryable<Models.MedicinesInPrescription>, IQueryable<Models.MedicinesInPrescription>> id_query, params object[] id)
        {
            queryLambda_where_id = x => x.Where(x => x.MedicineId == (int)id[0] && x.PrescriptionId == (int)id[1]);
        }

    }
}
