namespace Apps.Wise.Models.Response.Error;

public class ErrorResponse
{
    public string Error { get; set; }
    
    public string Message { get; set; }

    public override string ToString() => $"{Error}-{Message}";
}