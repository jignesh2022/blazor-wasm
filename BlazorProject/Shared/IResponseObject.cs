namespace BlazorProject.Shared
{
    public interface IResponseObject
    {
        dynamic Data { get; set; }
        string Message { get; set; }
        bool Success { get; set; }
    }
}