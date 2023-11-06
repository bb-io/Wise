using Apps.Wise.Extensions;
using Apps.Wise.Models.Request.Transfer;

namespace Apps.Wise.Models.Request.BatchGroup;

public class CreateBatchGroupTransferRequest
{
    public string TargetAccount { get; set; }

    public string QuoteUuid { get; set; }

    public string CustomerTransactionId { get; set; }

    public string? SourceAccount { get; set; }

    public TransferDetails Details { get; set; }

    public CreateBatchGroupTransferRequest(CreateBatchGroupTransferInput input, string quoteId)
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