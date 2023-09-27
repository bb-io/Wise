using Apps.Wise.Models.Entities;
using Apps.Wise.Models.Response.Base;
using Newtonsoft.Json;

namespace Apps.Wise.Models.Response.Transaction;

public class TransactionsPaginationResponse : PaginationResponse<TransactionEntity>
{
    [JsonProperty("transactions")]
    public override IEnumerable<TransactionEntity> Items { get; set; }
}