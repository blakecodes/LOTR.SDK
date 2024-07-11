namespace LOTR.SDK.Models;

public class ApiResponse<T>
{
    public IEnumerable<T> Docs { get; set; }
    public int Total { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
    public int Page { get; set; }
    public int Pages { get; set; }
}