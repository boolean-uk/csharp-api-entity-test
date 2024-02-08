using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository.PrescriptionRepo
{
    public class PrescriptionRepository : IPrescriptionRepository
    {

        private DatabaseContext _db;

        public PrescriptionRepository(DatabaseContext db) {
            _db = db;
        }

        public async Task<bool> addMedicine(int id, int medicine_id, int quantety, string note )
        {
            var prescription = await _db.Prescriptions.FindAsync(id);
            if (prescription == null)
            {
                return false;
            }
            var medicine = await _db.Medicines.FindAsync(medicine_id);
            if (medicine == null)
            {
                return false;
            }

            var existingPrescriptionMedicine = await _db.PrescriptionMedicines.FirstOrDefaultAsync(pm => pm.PrescriptionId == id && pm.MedicineId == medicine_id);

            if (existingPrescriptionMedicine != null)
            {
                existingPrescriptionMedicine.Quantity = quantety; 
                existingPrescriptionMedicine.Notes = note; 

                try
                {
                    await _db.SaveChangesAsync();
                    return true; // Successfully updated existing record
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Internal error: " + ex);
                    return false;
                }
            }

            prescription.PrescriptionMedicines.Add(new PrescriptionMedicine
            {
                PrescriptionId = id,
                Prescription = prescription,
                MedicineId = medicine_id,
                Medicine = medicine,
                Quantity = quantety,
                Notes = note
            }); // knas

            try
            {
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine("Internal error: " + ex);
                return false;
            }
        }

        public async Task<Prescription?> createPrescription(string? note, int appointment_id)
        {
            //var isAppointment = await _db.Appointments.FindAsync(appointment_id);
            
            var result = new Prescription { Notes = note, AppointmentId = appointment_id };
            _db.Prescriptions.Add(result);
            await _db.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<Medicine>> getAllMedicine()
        {
            return await _db.Medicines.Include(p => p.PrescriptionMedicines).ThenInclude(p => p.Prescription).ToArrayAsync();
        }

        public async Task<IEnumerable<Prescription>> getAllPrescriptions() {
            return await _db.Prescriptions.Include(p => p.PrescriptionMedicines).ThenInclude(m => m.Medicine).ToListAsync();
           
        }

        public async Task<Medicine?> getMedicineById(int medicine_id)
        {
            return await _db.Medicines.FindAsync(medicine_id);
        }

        public async Task<Prescription?> getPrescriptionById(int id)
        {
            return await _db.Prescriptions.FindAsync(id);
        }
    }
}

