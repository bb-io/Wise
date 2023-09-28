namespace Apps.Wise.Models.Request.Transfer;

public class CreateTransferRequest
{
    public string TargetAccount { get; set; }

    public string QuoteUuid { get; set; }

    public string CustomerTransactionId { get; set; }

    public string? SourceAccount { get; set; }

    public TransferDetails Details { get; set; }

    public CreateTransferRequest(CreateTransferInput input)
    {

        TargetAccount = input.TargetAccount;
        QuoteUuid = input.QuoteUuid;
        CustomerTransactionId = input.CustomerTransactionId;
        SourceAccount = input.SourceAccount;
        Details = new()
        {
            Reference = input.Reference,
            TransferPurpose = input.TransferPurpose,
            TransferPurposeSubTransferPurpose = input.TransferPurposeSubTransferPurpose,
            SourceOfFunds = input.SourceOfFunds,
        };
    }
}