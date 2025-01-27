using System;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data;

public class PatientData
{
    public List<Patient> Patients { get; set; } = new List<Patient>
    {
        new Patient
        {
            Id = 1,
            FullName = "John Doe",

        },

        new Patient
        {
            Id = 2,
            FullName = "Jane Doe",
        }
    };
}
