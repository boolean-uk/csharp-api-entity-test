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

        /// <summary>
        /// This function do add a medicine to a given prescription or update its parameters if the medicine already has been added to the prescription
        /// </summary>
        /// <param name="id"></param> prescription id
        /// <param name="medicine_id"></param> medicine id
        /// <param name="quantety"></param> the quantity of the medicine
        /// <param name="note"></param> description note on how to tae it, how often etc
        /// <returns></returns> false if data is missing of wrong type, true if everything succeeded 
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

        /// <summary>
        /// Creates a new prescription for a given appointment
        /// </summary>
        /// <param name="note"></param> string, can be empty if nothing is given
        /// <param name="appointment_id"></param> specified appointment
        /// <returns></returns> return null if appointment does not excists, else return the created prescription 
        public async Task<Prescription?> createPrescription(string? note, int appointment_id)
        {
            var isAppointment = await _db.Appointments.FindAsync(appointment_id);
            if (isAppointment == null)
            {
                return null;
            }
            
            var result = new Prescription { Notes = note, AppointmentId = appointment_id };
            _db.Prescriptions.Add(result);
            await _db.SaveChangesAsync();

            return result;
        }

        /// <summary>
        /// delete a given medicine from a given prescription
        /// </summary>
        /// <param name="medicine_id"></param> given medicine
        /// <param name="prescription_id"></param> given prescription
        /// <returns></returns> false if medicine or prescription does not exists or if something goes wrong during saving else true if deletion goes correct
        public async Task<bool> deleteMedicineFromPrescription(int medicine_id, int prescription_id)
        {
            var prescription = await _db.Prescriptions.FindAsync(prescription_id);
            if (prescription == null)
            {
                return false;
            }
            var prescriptionMedicine = await _db.PrescriptionMedicines.FirstOrDefaultAsync(p => p.PrescriptionId == prescription_id);
            if (prescriptionMedicine == null)
            {
                return false;
            }

            _db.PrescriptionMedicines.Remove(prescriptionMedicine);

            try
            {
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine("OBS"+ex.ToString());
                return false;
            }
        }

        public async Task<bool> deletePrescription(int prescription_id, int appointment_id)
        {
            var appointment = await _db.Appointments.FindAsync(appointment_id);
            if (appointment == null)
            {
                return false;
            }
            var prescription = await _db.Prescriptions.FindAsync(prescription_id);
            if (prescription == null)
            {
                return false;
            }

            _db.Prescriptions.Remove(prescription);
            try
            {
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine("OBS"+ex.ToString());
                return false;
            }
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

