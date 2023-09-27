namespace Apps.Wise.Models.Response.Error;

public class MultipleErrorsResponse
{
    public IEnumerable<CodeError> Errors { get; set; }
}