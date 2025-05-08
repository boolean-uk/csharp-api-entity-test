using System.Net;

namespace workshop.wwwapi.StatusPayloads
{
    public class Payload<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T data { get; set; }
    }
}
