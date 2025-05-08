namespace workshop.wwwapi.Payloads
{
    public class Payload<T1> where T1 : class
    {
        public string status { get; set; } = "success";
        public T1 data { get; set; }

    }

    public class Payload<T1, T2> where T1 : class where T2 : class
        {
            public T1 data1 { get; set; }
            public T2 data2 { get; set; }
        }
}
