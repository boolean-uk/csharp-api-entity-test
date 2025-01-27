namespace workshop.wwwapi.DTO.Request.MedicinesInPrescription
{
    public class Create
    {
        public Create() { }
        public Create(Models.MedicinesInPrescription p)
        {
            this.medicinId = p.MedicineId;
            this.quantity = p.quantity;
            this.note = p.note;
        }
        public int medicinId { get; set; }
        public int quantity { get; set; }
        public string note { get; set; }

    }
}
