using System.Net;
using Apps.Wise.Constants;
using Apps.Wise.Webhooks.Handlers;
using Apps.Wise.Webhooks.Models.Balance;
using Apps.Wise.Webhooks.Models.Base;
using Apps.Wise.Webhooks.Models.Payment;
using Apps.Wise.Webhooks.Models.Swift;
using Apps.Wise.Webhooks.Models.Transfer;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.Wise.Webhooks.Lists;

[WebhookList]
public class WebhookList
{
    #region Webhooks

    [Webhook("On account credited", typeof(BalanceCreditWebhookHandler),
        Description = "On multi-currency account is credited")]
    public Task<WebhookResponse<BalanceCreditPayload>> OnBalanceCredit(WebhookRequest request)
        => HandleWebhookRequest<BalanceCreditPayload>(request);

    [Webhook("On balance updated", typeof(BalanceUpdateWebhookHandler),
        Description = "On a specific balance updated")]
    public Task<WebhookResponse<BalanceUpdatePayload>> OnBalanceUpdated(WebhookRequest request)
        => HandleWebhookRequest<BalanceUpdatePayload>(request);

    [Webhook("On payment initiations state changed", typeof(BatchPaymentStateChangedWebhookHandler),
        Description = "On payment initiation state of a batch group payment changed")]
    public Task<WebhookResponse<BatchPaymentStateChangedPayload>> OnBatchPaymentStateChanged(WebhookRequest request)
        => HandleWebhookRequest<BatchPaymentStateChangedPayload>(request, JsonConfig.CamelCaseSettings);

    [Webhook("On SWIFT message received and a credit deposited", typeof(SwiftInCreditWebhookHandler),
        Description = "On SWIFT message is received and a credit is deposited into a balance account")]
    public Task<WebhookResponse<SwiftInCreditPayload>> OnSwiftInCredit(WebhookRequest request)
        => HandleWebhookRequest<SwiftInCreditPayload>(request);

    [Webhook("On transfer status updated", typeof(TransferStateChangedWebhookHandler),
        Description = "On a specific transfer's status updated")]
    public Task<WebhookResponse<TransferStateChangedPayload>> OnTrasferStateChanged(WebhookRequest request)
        => HandleWebhookRequest<TransferStateChangedPayload>(request);

    [Webhook("On transfer active cases updated", typeof(TransferActiveCasesWebhookHandler),
        Description = "On transfer's list of active cases is updated")]
    public Task<WebhookResponse<TransferActiveCasesPayload>> OnTransferActiveCases(WebhookRequest request)
        => HandleWebhookRequest<TransferActiveCasesPayload>(request);

    [Webhook("On transfer payout failed", typeof(TransferPayoutFailedWebhookHandler),
        Description = "On a specific transfer's payout failed")]
    public Task<WebhookResponse<TransferPayoutFailedPayload>> OnTrasferPayoutFailed(WebhookRequest request)
        => HandleWebhookRequest<TransferPayoutFailedPayload>(request);

    #endregion

    #region Utils

    public async Task<WebhookResponse<T>> HandleWebhookRequest<T>(WebhookRequest request,
        JsonSerializerSettings? serializerSettings = null) where T : class
    {
        if (request.Headers.TryGetValue("x-test-notification", out var testNotif) || testNotif == "true")
            return await Task.FromResult(new WebhookResponse<T>
            {
                HttpResponseMessage = new HttpResponseMessage() { StatusCode = HttpStatusCode.OK },
                Result = null,
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            });

        var payload = request.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload, nameof(request.Body));

        var result =
            JsonConvert.DeserializeObject<WiseWebhookResponse<T>>(payload,
                serializerSettings ?? JsonConfig.SnakeCaseSettings)!;

        return await Task.FromResult(new WebhookResponse<T>
        {
            HttpResponseMessage = new HttpResponseMessage() { StatusCode = HttpStatusCode.OK },
            Result = result.Data
        });
    }

    #endregion
}