using Apps.Wise.Models.Entities;
using Apps.Wise.Models.Response.Base;
using Newtonsoft.Json;

namespace Apps.Wise.Models.Response.Card;

public class CardsPaginationResponse : PaginationResponse<CardEntity>
{
    [JsonProperty("cards")]
    public override IEnumerable<CardEntity> Items { get; set; }
}