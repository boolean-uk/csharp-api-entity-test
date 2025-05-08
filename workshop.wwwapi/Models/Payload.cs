namespace workshop.wwwapi.Models
{
    public class Payload<T>(T data) where T : class
    {
        public string status { get; set; } = "Success";

        public DateTime creationTime { get; } = DateTime.Now;

        public T Data { get; set; } = data;
    }

    public class Payload<T1, T2>(T1 Data, T2 Data2) where T1 : class where T2 : class 
    {
        public string status { get; set; } = "Success";

        public DateTime creationTime { get; set; } = DateTime.Now;

        public T1 Data { get; set; } = Data;

        public T2 Data2 { get; set; } = Data2;
    }
}
