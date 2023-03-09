namespace Proyecto.Core.Http;

public class Response<T>
{
    public T Data { get; set; }
    public string message { get; set; } = "";
    public List<String> Errors { get; set; } = new List<string>();
}