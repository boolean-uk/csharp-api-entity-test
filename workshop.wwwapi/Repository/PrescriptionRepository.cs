using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {

        private DatabaseContext db;

        public PrescriptionRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public async Task<Prescription?> AddPrescriptionToAppointment(int PrescriptionId, int AppointmendId)
        {
            var appointment = await db.Appointments.FirstOrDefaultAsync(A => A.Id == AppointmendId);

            if (appointment == null) { return null; }

            var Prescription = await db.Prescriptions.FirstOrDefaultAsync(P => P.Id == PrescriptionId);

            if (Prescription == null) { return null; }

            appointment.Prescription = Prescription;

            db.SaveChanges();
            Prescription? returnPrescription = await db.Prescriptions.Include(p => p.Appointment).FirstOrDefaultAsync(P => P.Id == PrescriptionId);

            return returnPrescription;

        }

        public async Task<Prescription?> CreatePrescription(List<int> MedcinesId)
        {
            List<Medicine> medicines = db.Medicines.Where(m => MedcinesId.Contains(m.Id)).ToList();
            if (!medicines.Any()) { return null; }

            Prescription prescription = new Prescription();

            db.Prescriptions.Add(prescription);
            db.SaveChanges();
            prescription.Medicines.AddRange(medicines);
            db.SaveChanges();


            return prescription;

        }

        public async Task<Prescription?> DeletePrescriptionById(int PrescriptionId)
        {
            var Prescription = await db.Prescriptions.FirstOrDefaultAsync(P => P.Id == PrescriptionId);
            if (Prescription == null) {  return null; }
            db.Prescriptions.Remove(Prescription);
            db.SaveChanges();
            return Prescription;
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            var Prescription = await db.Prescriptions
                .Include(P => P.Medicines)
                .Include(P => P.Appointment).ThenInclude(A => A.Doctor)
                .Include(P => P.Appointment).ThenInclude(A => A.Patient)
                .ToListAsync();
            return Prescription;
        }
    }
}