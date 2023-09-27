using Apps.Wise.Models.Entities;

namespace Apps.Wise.Models.Response.Transaction;

public record ListTransactionsResponse(TransactionEntity[] Transactions);