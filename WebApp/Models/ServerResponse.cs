namespace SermonCentral.Spark.Models;

public class ServerResponse
{
    public object Data { get; set; }
    public string Message { get; set; }

              
    public ServerResponse(object data, string message = null)
    {
        Message = message;
        Data = data;
    }
        
    public ServerResponse(string message)
    {
        Message = message;
    }
}