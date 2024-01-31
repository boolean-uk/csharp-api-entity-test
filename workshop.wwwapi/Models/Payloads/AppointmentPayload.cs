namespace workshop.wwwapi.Models.Payloads
{
    public record AppointmentPayload
    {
        public required int Doctor_id { get; set; }
        public required int Patient_id { get; set; }
    }
}