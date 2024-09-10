using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("doctors")]
    public class Doctor
    {
        [Column("id")]
        private int _id;
        [Column("firstname")]
        private string _firstname;
        [Column("lastname")]
        private string _lastname;

        private List<Appointment> _appointments = new List<Appointment>();
        public int Id { get => _id; set => _id = value; }
        public string FirstName { get => _firstname; set => _firstname = value; }
        public string LastName { get => _lastname; set => _lastname = value; }
        public List<Appointment> Appointments { get => _appointments; set => _appointments = value; }
    }
}
