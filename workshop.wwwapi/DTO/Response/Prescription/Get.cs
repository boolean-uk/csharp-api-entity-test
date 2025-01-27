
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.DTO.Response.Prescription
{
    public class Get : BaseDTO<Get,Models.Prescription>
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public List<MedicinesInPrescription.Get> mediciensInPrescription { get; set; }

        public override void define_include_queries(ref List<Func<IQueryable<Models.Prescription>, IQueryable<Models.Prescription>>> queryLambda)
        {

            queryLambda.Add(x => x.Include(x => x.Doctor).
                Include(x => x.Patient).
                Include(x => x.MedicinesInPrescription)
                .ThenInclude(x => x.Medicine));
        }

        public override void define_where_query_for_id(ref Func<IQueryable<Models.Prescription>, IQueryable<Models.Prescription>> id_query, params object[] id)
        {
            id_query = x => x.Where(x => x.Id == (int)id[0]);

        }

        public override void Instantiate(Models.Prescription instance)
        {
            DoctorId = instance.DoctorId;
            PatientId = instance.PatientId;
            DoctorName = instance.Doctor.FullName;
            PatientName = instance.Patient.FullName;
            mediciensInPrescription = ToDTOs<Models.MedicinesInPrescription, MedicinesInPrescription.Get>(instance.MedicinesInPrescription).ToList();
        }
    }

}
