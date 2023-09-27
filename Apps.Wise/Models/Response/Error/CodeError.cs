namespace Apps.Wise.Models.Response.Error;

public class CodeError
{
    public string Code { get; set; }
    
    public string Message { get; set; }
    
    public string? Path { get; set; }

    public override string ToString() => $"{Code}-{Message}-{Path}";
}