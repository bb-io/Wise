namespace Apps.Wise.Webhooks.Models.Base;

public class WiseWebhookResponse<T>
{
    public T Data { get; set; }
}