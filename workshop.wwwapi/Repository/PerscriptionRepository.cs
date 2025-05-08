
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class PerscriptionRepository : Repository<Perscription>, IPerscriptionRepository
    {

        private DatabaseContext _databaseContext;
        private readonly DbSet<Perscription> _dbSet;
        public PerscriptionRepository(DatabaseContext db) : base( db)
        {
            _databaseContext = db;
            _dbSet = db.Set<Perscription>();
        }
        public async Task Create(Perscription entity)
        {
            if (entity == null)
            {
                 throw new ArgumentNullException(entity + "element not found");
            }
            _dbSet.Add(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Perscription>> GetAllPerscriptions()
        {
            return await _databaseContext.Perscriptions
                 .Include(a => a.Medicines)
                 .Include(a => a.Appointment)
                 .ToListAsync();
        }

        public async Task<Perscription> GetOne(int id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(id+" id not found");
            }
            return await _dbSet.Where(a => a.Id == id)
                .Include(a => a.Medicines)
                .Include(a => a.Appointment)
                .SingleOrDefaultAsync();

            
                
        }

        public async Task InjectToAppointment(int appointmentId, int perscriptionId)
        {
            var appointment = _databaseContext.Appointments.FirstOrDefault(x => x.Id==perscriptionId);
            var perscription = GetOne(perscriptionId);
            appointment.PerscriptionId = perscriptionId;
            appointment.Perscription = await perscription;
             await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Medicine>> GetMedicinesByPrescriptionIdAsync(int prescriptionId)
        {
            return await _databaseContext.Perscriptions
                .Where(p => p.Id == prescriptionId)
                .SelectMany(p => p.Medicines)
                .ToListAsync();
        }

        public async Task<Medicine> GetMedicineById(int id)
        {
      
            if (id == null)
            {
                throw new ArgumentNullException(id + "did not find id");
            }
            return await _databaseContext.Medicines.FindAsync(id);
        }
    }
}
