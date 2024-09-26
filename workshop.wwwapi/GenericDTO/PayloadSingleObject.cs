namespace workshop.wwwapi.GenericDTO
{
    public class PayloadSingleObject<T> where T : class
    {
         public T data { get; set; }
    }
}
