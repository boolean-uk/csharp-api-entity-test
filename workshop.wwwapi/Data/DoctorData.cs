using System;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data;

public class DoctorData
{
    public List<Doctor> Doctors { get; set; } = new List<Doctor>
    {
        new Doctor { Id = 1, FullName = "Dr. John Doe" },
        new Doctor { Id = 2, FullName = "Dr. Jane Doe" },
        new Doctor { Id = 3, FullName = "Dr. James Smith" },
        new Doctor { Id = 4, FullName = "Dr. Mary Smith" }
    };
}
