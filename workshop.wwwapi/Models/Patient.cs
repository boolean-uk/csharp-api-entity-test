﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
      

    [Table("patient")]
    public class Patient
    {
        [Column("id")]          //By convention, a property named Id or <type name>Id will be configured as the primary key of an entity.
        [Key]
        public int Id { get; set; }
        
        [Column("fullname")]
        public string FullName { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();        //COMMENT: This does not generate a column on the table actually!
    }
}
