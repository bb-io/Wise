namespace Apps.Wise.Models.Response.Base;

public class PaginationResponse<T>
{
    public virtual IEnumerable<T> Items { get; set; }
    public int TotalCount { get; set; }
}