using Apps.Wise.Extensions;

namespace Apps.Wise.Models.Request.Transfer;

public class CreateTransferRequest
{
    public string TargetAccount { get; set; }

    public string QuoteUuid { get; set; }

    public string CustomerTransactionId { get; set; }

    public string? SourceAccount { get; set; }

    public TransferDetails Details { get; set; }

    public CreateTransferRequest(CreateTransferInput input, string quoteId)
    {

        TargetAccount = input.TargetAccount;
        QuoteUuid = quoteId;
        CustomerTransactionId = input.TransactionIdentifier?.AsGuid() ?? Guid.NewGuid().ToString() ;
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