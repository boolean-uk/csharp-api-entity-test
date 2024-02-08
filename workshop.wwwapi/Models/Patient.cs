﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("patients")]
    [PrimaryKey("Id")]
    public class Patient
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
