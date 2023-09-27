using Blackbird.Applications.Sdk.Utils.Extensions.String;

namespace Apps.Wise.Models.Request.Webhook;

public class CreateWebhookRequest
{
    public string Name { get; set; }
    
    public string TriggerOn { get; set; }
    
    public WebhookDelivery Delivery { get; set; }

    public CreateWebhookRequest(string @event, string url)
    {
        Name = $"BlackBird-{@event}-{url.ToUri().Segments.Last()}";
        TriggerOn = @event;
        Delivery = new()
        {
            Url = url,
            Version = "2.0.0"
        };
    }
}