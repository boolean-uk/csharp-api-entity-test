namespace workshop.wwwapi.DTO.Request.Doctor
{
    public class Create
    {
        public Create() { }
        public Create(Models.Doctor d)
        {
            FullName = d.FullName;
        }
        public string FullName { get; set; }
    }
}
