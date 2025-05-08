using System;

namespace workshop.wwwapi.Payload;

public class Payload<T>
{

    public T Data {get;set;}
    public bool GoodResponse {get;set;} = true;
    public string Message {get;set;} = "Success";

    public Payload() {}

}
