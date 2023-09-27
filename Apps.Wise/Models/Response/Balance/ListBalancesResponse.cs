using Apps.Wise.Models.Entities;

namespace Apps.Wise.Models.Response.Balance;

public record ListBalancesResponse(BalanceEntity[] Balances);