namespace workshop.wwwapi.DTOs
{
    public class CreatePerscriptionDTO
    {

        public int Id  { get; set; }
        public int appointmentId { get; set; }

        public int[] medicineIds { get; set; }

       

    }
}
