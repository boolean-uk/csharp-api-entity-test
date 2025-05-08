using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class MedPrescriptionRepository : IMedPrescriptionRepository
    {
        private DatabaseContext _databaseContext;
        public MedPrescriptionRepository(DatabaseContext db)
        {
            _databaseContext = db;
        }


        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await _databaseContext.Medicines.Include(x => x.MedicinePrescriptions).ThenInclude(x => x.Prescription).ToListAsync();
        }

        public async Task<Medicine?> GetMedicine(int MedicineId)
        {
            return await _databaseContext.Medicines.Include(x => x.MedicinePrescriptions).ThenInclude(x => x.Prescription).FirstOrDefaultAsync(s => s.Id == MedicineId); 
        }

        public async Task<Medicine?> CreateMedicine(string name)
        {
            if (name == "") return null;
            var Medicine = new Medicine { Name = name };
            await _databaseContext.Medicines.AddAsync(Medicine);
            return Medicine;
        }



        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.Include(x => x.MedicinePrescriptions).ThenInclude(x => x.Medicine).ToListAsync();
        }

        public async Task<Prescription?> GetPrescription(int id, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _databaseContext.Prescriptions.Include(x => x.MedicinePrescriptions).ThenInclude(x => x.Medicine).FirstOrDefaultAsync(s => s.Id == id);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _databaseContext.Prescriptions.FirstOrDefaultAsync(s => s.Id == id);
                default:
                    return null;
            }
        }

        public async Task<Prescription?> CreatePrescription(int medId, int quantity, string notes)
        {
            if (medId.GetType() != typeof(int)) return null;

            var d = _databaseContext.Medicines.FirstOrDefault(x => x.Id == medId);

            if(d == null)
            {
                return null;
            }
           
            var pres = new Prescription { Quantity = quantity, Notes = notes };
            await _databaseContext.Prescriptions.AddAsync(pres);

            var medpres = new MedicinePrescription { MedicineId = d.Id, Medicine = d, PrescriptionId = pres.Id, Prescription = pres };

            await _databaseContext.MedicinePrescriptions.AddAsync(medpres);

            return pres;
        }


        public async Task<Appointment?> AttachPrescriptionToAppointment(int presId, int doctorId, int patientId)
        {
            if (presId.GetType() != typeof(int) || doctorId.GetType() != typeof(int) || patientId.GetType() != typeof(int)) return null;
            
            var p = await _databaseContext.Prescriptions.Include(d => d.MedicinePrescriptions).ThenInclude(x => x.Medicine).FirstOrDefaultAsync(p => p.Id == presId);
            var a = await _databaseContext.Appointments.Include(d => d.Doctor).Include(x => x.Patient).Where(x => x.PatientId == patientId).FirstOrDefaultAsync(x => x.DoctorId == doctorId);

            if (p == null || a == null)
            {
                return null;
            }

            a.Prescription = p;

            return a;
        }


        public void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }

    }
}
