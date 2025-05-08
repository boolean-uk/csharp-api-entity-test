namespace workshop.wwwapi.Models.Dto.GenericDto
{
    public class Payload<T> where T : class
    {
        public string status { get; set; } = "success";
        public T data { get; set; }
    }
}
