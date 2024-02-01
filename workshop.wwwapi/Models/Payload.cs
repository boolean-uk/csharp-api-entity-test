namespace workshop.wwwapi.Models
{
    public class Payload<T>(T data) where T : class
    {
        public string status { get; set; } = "Success";

        public DateTime creationTime { get; } = DateTime.Now;

        public T Data { get; set; } = data;
    }
}
