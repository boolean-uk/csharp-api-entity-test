﻿using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository.PrescriptionRepo
{
    public interface IPrescriptionRepository
    {
        Task<bool> addMedicine(int id, int medicine_id, int quantity, string note);
        Task<Prescription?> createPrescription(string? note, int appointment_id);
        Task<IEnumerable<Medicine>> getAllMedicine();
        Task<IEnumerable<Prescription>> getAllPrescriptions();
        Task<Medicine?> getMedicineById(int medicine_id);
        Task<Prescription?> getPrescriptionById(int id);
    }
}
