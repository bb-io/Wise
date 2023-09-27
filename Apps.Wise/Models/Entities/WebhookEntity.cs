using Apps.Wise.Models.Request.Webhook;

namespace Apps.Wise.Models.Entities;

public class WebhookEntity
{
    public string Id { get; set; }
    
    public WebhookDelivery Delivery { get; set; }
}