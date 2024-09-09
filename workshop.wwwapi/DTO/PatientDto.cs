﻿using Swashbuckle.AspNetCore.Annotations;

namespace workshop.wwwapi.DTO
{
    public class PatientDto
    {
        public string FullName { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public List<PatientAppointement> Appointements { get; set; } = new List<PatientAppointement>();
    }

    public class PatientAppointement
    {
        public DateTime time { get; set; }
        public PatientDoctor Doctor { get; set; }
        public List<PatientMedicine> Medicines { get; set; }
    }
    public class PatientDoctor
    {
        public string Name { get; set; }
    }
    public class PatientMedicine
    {
        public string Name { get; set; }
        public string Instruction { get; set; }
    }
}
