﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("patients")]
    [PrimaryKey("Id")]
    public class Patient
    {
        [Column("patient_id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
