using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class MedicinPerscription
    {
        public int Id { get; set; }

        [ForeignKey ("perscriptionid"), Column("perscriptionid")]
        public int PerscriptionId { get; set; }

        [ForeignKey ("medicineid"), Column("medicineid")]
        public int medicineid { get; set; }
        public Medicine Medicine { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("note")]
        public string Note { get; set; }
    }
}
